﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Sketcher
{
    public enum Tool { PENCIL = 0, RECTANGLE, ELLIPSE }
   

    public partial class Form1 : Form
    {
        private Point startPoint;
        private Tool currentTool;
        private String[] toolImageNames;
        private String[] toolNames;
        private PictureBox[] toolIcons;
        private bool isDrawing;
        private bool hasBeenModified;
        private bool shouldFormailzed;
        private String currentPath = "";
        private static Point nullPoint = new Point(-100000, -100000);
        private Cursor canvasCursor;
        private Point anchorPointForFormalizedShape;
        private Button[] widthButtons;

        private Pen drawPen = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            currentTool = Tool.PENCIL;
            toolImageNames = new String[] { "btn_pencil", "btn_rectangle", "btn_ellipse" };
            toolNames = new String[] { "Pencil Tool", "Rectangle Tool", "Ellipse Tool" };
            startPoint = nullPoint;

            isDrawing = false;
            shouldFormailzed = false;
            canvasCursor = this.Cursor;
        }

        private void setToolTips()
        {
            for (int i = 0; i < toolIcons.Length; ++i)
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(toolIcons[i], toolNames[i]);
                tt.AutoPopDelay = 2000;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetAutoSizeMode(AutoSizeMode);
            toolIcons = new PictureBox[] { pencilTool, rectangleTool, ellipseTool};
            this.pencilTool_Click_1(null, null);
            setToolTips();
            newCanvas();

            tempCanvas.Parent = canvas;
            tempCanvas.Location = new Point(0, 0);
            newTempCanvas();
            widthButtons = new Button[] { button1, button2, button3, button4, button5 };
            changeColor(Color.Black);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isDrawing)
            {
                if (e.KeyChar == (char) 27) 
                {
                    newTempCanvas();
                    statusStrip.Items[0].Text = "Cancel current drawing.";
                    isDrawing = false;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.Out.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (Constants.TOOLS_CAN_BE_FORMALIZED.Contains(currentTool))
                {
                    statusStrip.Items[0].Text = "Formalize the shape.";
                    shouldFormailzed = true;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (Constants.TOOLS_CAN_BE_FORMALIZED.Contains(currentTool))
                {
                    statusStrip.Items[0].Text = "";
                    shouldFormailzed = false;
                }
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.Out.WriteLine("MouseDown on canvas");
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            startPoint = new Point(e.X, e.Y);
            isDrawing = true;

            newTempCanvas();

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) {
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            
            if (startPoint != nullPoint)
            {
                if (e.Button == MouseButtons.Left)
                {
                    using (Graphics g = Graphics.FromImage(tempCanvas.Image))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        Point tempPoint = new Point(e.Location.X, e.Location.Y);
                        switch (currentTool)
                        {
                            case Tool.PENCIL:
                                g.DrawLine(drawPen, startPoint, tempPoint);
                                startPoint = tempPoint;
                                break;

                            case Tool.RECTANGLE:
                            case Tool.ELLIPSE:
                                g.Clear(Color.Transparent);

                                Rectangle rect = Rectangle.Empty;
                                int rectWidth, rectHeight, rectX, rectY;

                                if (shouldFormailzed)
                                {
                                    rectWidth = Math.Abs(startPoint.X - tempPoint.X);
                                    rectHeight = Math.Abs(startPoint.Y - tempPoint.Y);
                                    rectWidth = rectHeight = Math.Min(rectWidth, rectHeight);
                                    rectX = (startPoint.X < tempPoint.X) ? startPoint.X : startPoint.X - rectWidth;
                                    rectY = (startPoint.Y < tempPoint.Y) ? startPoint.Y : startPoint.Y - rectHeight;
                                }
                                else
                                {
                                    rectWidth = Math.Abs(startPoint.X - tempPoint.X);
                                    rectHeight = Math.Abs(startPoint.Y - tempPoint.Y);
                                    rectX = (startPoint.X < tempPoint.X) ? startPoint.X : tempPoint.X;
                                    rectY = (startPoint.Y < tempPoint.Y) ? startPoint.Y : tempPoint.Y;
                                }

                                
                                if (!shouldFormailzed) anchorPointForFormalizedShape = new Point(rectX, rectY);

                                rect = new Rectangle(rectX, rectY, rectWidth, rectHeight);

                                if (currentTool == Tool.RECTANGLE) g.DrawRectangle(drawPen, rect);
                                else g.DrawEllipse(drawPen, rect.X, rect.Y, rect.Width, rect.Height);

                                break;
                        }
                        tempCanvas.Invalidate();
                    }
                }
            }
        }

        private void canvas_MouseUP(object sender, MouseEventArgs e) {
            //Console.Out.WriteLine("MouseDown off canvas");
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            if (isDrawing)
            {
                hasBeenModified = true;
                using (Graphics g = Graphics.FromImage(canvas.Image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawImage(tempCanvas.Image, new Point(0, 0));
                }
                newTempCanvas();

                isDrawing = false;
                startPoint = nullPoint;

                switch (currentTool)
                {
                    case Tool.PENCIL:
                        statusStrip.Items[0].Text = "Something was drawn.";
                        break;
                    case Tool.RECTANGLE:
                        statusStrip.Items[0].Text = "A rectangle was drawn.";
                        break;
                    case Tool.ELLIPSE:
                        statusStrip.Items[0].Text = "An ellipse was drawn.";
                        break;
                }
            }
        }


        private void pencilTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.PENCIL);
            canvasCursor = Cursors.Default;
        }

        private void rectangleTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.RECTANGLE);
            canvasCursor = Cursors.Cross;
        }

        private void ellipseTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.ELLIPSE);
            canvasCursor = Cursors.Cross;
        }

        private void changeTool(Tool t)
        {
            Console.Out.WriteLine("change tool from " + toolImageNames[(int)currentTool] + " to " + toolImageNames[(int)t]);
            toolIcons[(int) currentTool].Image
                = (Image)Properties.Resources.ResourceManager.GetObject(toolImageNames[(int)currentTool] + "_normal");
            toolIcons[(int) t].Image
                = (Image) Properties.Resources.ResourceManager.GetObject(toolImageNames[(int) t] + "_selected");
            currentTool = t;
            statusStrip.Items[0].Text = "Change to " + toolNames[(int) currentTool] + ".";
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkBeforeQuit(null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|All image files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            ofd.FilterIndex = 6;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                canvas.Image = Image.FromFile(ofd.FileName);
                canvas.Refresh();
                canvas.SizeMode = PictureBoxSizeMode.AutoSize;
                statusStrip.Items[0].Text = "Open file " + ofd.FileName;
                currentPath = ofd.FileName;
                this.Text = "Sketcher - " + ofd.FileName;
                hasBeenModified = false;
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            // If the file has been modified, popup dialog to ask the user to check that
            newCanvas();
            currentPath = "";
            this.Text = "Sketcher - Untitled";
            hasBeenModified = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPath == "")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                canvas.Image.Save(currentPath);
                statusStrip.Items[0].Text = "Image has been saved.";
                hasBeenModified = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            sfd.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg|PNG|*.png|TIFF|*.tiff";
            sfd.FilterIndex = 4;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = (FileStream) sfd.OpenFile();

                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                switch(sfd.FilterIndex)
                {
                    case 1: format = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    case 2: format = System.Drawing.Imaging.ImageFormat.Gif; break;
                    case 3: format = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                    case 4: format = System.Drawing.Imaging.ImageFormat.Png; break;
                    case 5: format = System.Drawing.Imaging.ImageFormat.Tiff; break;
                }
                canvas.Image.Save(fs, format);
                fs.Close();
                currentPath = sfd.FileName;
                this.Text = "Sketcher - " + sfd.FileName;
                statusStrip.Items[0].Text = "Image has been saved.";
                hasBeenModified = false;
            }
        }

        private void newCanvas()
        {
            Bitmap bmp = new Bitmap(Constants.DEFAULT_CANVAS_WIDTH, Constants.DEFAULT_CANVAS_HEIGHT);
            Graphics.FromImage(bmp).Clear(Color.White);
            canvas.Image = bmp;
        }

        private void newTempCanvas()
        {
            Bitmap bmp = new Bitmap(Constants.DEFAULT_CANVAS_WIDTH, Constants.DEFAULT_CANVAS_HEIGHT);
            tempCanvas.Image = bmp;
        }

        private void saveTempCanvas()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            sfd.Filter = "PNG|*.png";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = (FileStream)sfd.OpenFile();

                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                tempCanvas.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                fs.Close();
            }
        }

        static class Constants
        {
            public const int DEFAULT_CANVAS_WIDTH = 800;
            public const int DEFAULT_CANVAS_HEIGHT = 600;
            public static readonly Tool[] TOOLS_CAN_BE_FORMALIZED = { Tool.RECTANGLE, Tool.ELLIPSE };
        }

        private void canvas_MouseEnter(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Mouse entered canvas");
            this.Cursor = canvasCursor;
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Mouse left canvas");
            canvasCursor = this.Cursor;
            this.Cursor = Cursors.Default;
        }

        private void aboutSketcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just a practice by Acsa Lu (acsa0210@gmail.com)");
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                changeColor(colorDialog1.Color);
            }
        }

        private void changeColor(Color c)
        {
            pictureBox1.BackColor = colorDialog1.Color;
            drawPen.Color = colorDialog1.Color;

            for (int i = 0; i < widthButtons.Length; ++i)
            {
                Button b = widthButtons[i];
                b.BackgroundImage = new Bitmap(b.Width, b.Height);
                using (Graphics g = Graphics.FromImage(b.BackgroundImage))
                { 
                    g.DrawLine(new Pen(c, 2 * i + 1), new Point(b.Width / 2, 5), new Point(b.Width / 2, b.Height - 5));
                }
            }

            statusStrip.Items[0].Text = "Change color.";
        }

        private void widthButton_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            drawPen.Width = 2 * Array.IndexOf(widthButtons, b) + 1;
            statusStrip.Items[0].Text = "Change the pen width to " + drawPen.Width + ".";

        }

        private void checkBeforeQuit(FormClosingEventArgs e)
        {
            if (hasBeenModified)
            {
                String message = "You have modified this image. Do you want to save it before quit?";
                switch ((MessageBox.Show(message, "haha", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)))
                {
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        this.Dispose();
                        break;
                    case DialogResult.No:
                        this.Dispose();
                        break;
                    case DialogResult.Cancel:
                        if (e != null) e.Cancel = true;
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkBeforeQuit(e);
        }

    }
}
