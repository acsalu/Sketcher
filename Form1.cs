using System;
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
        private Graphics g;
        private Point startPoint;
        private Tool currentTool;
        private String[] toolImageNames;
        private String[] toolNames;
        private PictureBox[] toolIcons;
        private bool isDrawing;
        private bool shouldFormailzed;

        private Rectangle oldRect;

        public Form1()
        {
            InitializeComponent();
            currentTool = Tool.PENCIL;
            toolImageNames = new String[] { "btn_pencil", "btn_rectangle", "btn_ellipse" };
            toolNames = new String[] { "Pencil Tool", "Rectangle Tool", "Ellipse Tool" };
            oldRect = new Rectangle(0, 0, 0, 0);

            isDrawing = false;
            shouldFormailzed = false;
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
            toolIcons = new PictureBox[] { pencilTool, rectangleTool, ellipseTool};
            this.pencilTool_Click_1(null, null);
            setToolTips();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isDrawing)
            {
                if (e.KeyChar == (char) 27) 
                {
                    statusStrip.Items[0].Text = "Cancel current drawing.";
                    isDrawing = false;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.Out.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Shift)
            {
                statusStrip.Items[0].Text = "Formalize the shape.";
                shouldFormailzed = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Shift)
            {
                statusStrip.Items[0].Text = "";
                shouldFormailzed = false;
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.Out.WriteLine("MouseDown on canvas");
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            
            Pen drawPen = new Pen(Color.Black, 1);
            g = canvas.CreateGraphics();
            startPoint = new Point(e.X, e.Y);
            isDrawing = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) {
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            
            if (g != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Pen drawPen = new Pen(Color.Black, 1);
                    Point tempPoint = new Point(e.Location.X, e.Location.Y);
                    switch (currentTool)
                    {
                        case Tool.PENCIL:
                            g.DrawLine(drawPen, startPoint, tempPoint);
                            startPoint = tempPoint;
                            break;
                        case Tool.RECTANGLE:
                        case Tool.ELLIPSE:
                            if (oldRect.Width != 0 || oldRect.Height != 0)
                            {
                                if (currentTool == Tool.RECTANGLE) g.DrawRectangle(new Pen(canvas.BackColor), oldRect);
                                else g.DrawEllipse(new Pen(canvas.BackColor), oldRect.X, oldRect.Y, oldRect.Width, oldRect.Height);
                            }
                            int rectWidth = Math.Abs(startPoint.X - tempPoint.X);
                            int rectHeight = Math.Abs(startPoint.Y - tempPoint.Y);
                            int rectX = (startPoint.X < tempPoint.X) ? startPoint.X : tempPoint.X;
                            int rectY = (startPoint.Y < tempPoint.Y) ? startPoint.Y : tempPoint.Y;
                            Rectangle rect = new Rectangle(rectX, rectY, rectWidth, rectHeight);

                            if (currentTool == Tool.RECTANGLE) g.DrawRectangle(drawPen, rect);
                            else g.DrawEllipse(drawPen, rect.X, rect.Y, rect.Width, rect.Height);

                            oldRect = rect;
                            break;
                    }
                }
            }
        }

        private void canvas_MouseUP(object sender, MouseEventArgs e) {
            //Console.Out.WriteLine("MouseDown off canvas");
            //Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            isDrawing = false;
            if (g != null) g.Dispose();
            g = null;

            switch (currentTool)
            {
                case Tool.PENCIL:
                    break;
                case Tool.RECTANGLE:
                    oldRect = new Rectangle(0, 0, 0, 0);
                    statusStrip.Items[0].Text = "A rectangle is drawn.";
                    break;
                case Tool.ELLIPSE:
                    statusStrip.Items[0].Text = "An ellipse is drawn.";
                    oldRect = new Rectangle(0, 0, 0, 0);
                    break;
            }
        }

        private void pencilTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.PENCIL);
            this.Cursor = Cursors.Default;
        }

        private void rectangleTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.RECTANGLE);
            this.Cursor = Cursors.Cross;
        }

        private void ellipseTool_Click_1(object sender, EventArgs e)
        {
            changeTool(Tool.ELLIPSE);
            this.Cursor = Cursors.Cross;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|All Image Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            ofd.FilterIndex = 6;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                canvas.Image = Image.FromFile(ofd.FileName);
                canvas.Refresh();
            }

        }

        

    }
}
