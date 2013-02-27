using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Sketcher
{
    public enum Tools { PENCIL, ERASER, RECTANGLE, CIRCLE }

    public partial class Form1 : Form
    {
        private Graphics g;
        private Point startPoint;
        private ResourceManager rm;
        private Tools currentTool;


        public Form1()
        {
            InitializeComponent();
            rm = new ResourceManager("rmc", Assembly.GetExecutingAssembly());
            currentTool = Tools.PENCIL;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Console.Out.WriteLine("MouseDown on canvas");
            Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            
            Pen drawPen = new Pen(Color.Black, 1);
            g = canvas.CreateGraphics();
            startPoint = new Point(e.X, e.Y);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) {
            Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");

            if (g != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Pen drawPen = new Pen(Color.Black, 1);
                    Point tempPoint = new Point(e.Location.X, e.Location.Y);
                    g.DrawLine(drawPen, startPoint, tempPoint);
                    startPoint = tempPoint;
                }
            }
        }

        private void canvas_MouseUP(object sender, MouseEventArgs e) {
            Console.Out.WriteLine("MouseDown off canvas");
            Console.Out.WriteLine("(" + e.Location.X + ", " + e.Location.Y + ")");
            g.Dispose();
            g = null;
        }

        private void pencilTool_Click_1(object sender, EventArgs e)
        {
            pencilTool.Image = (Image)Properties.Resources.ResourceManager.GetObject("btn_pencil_selected");
        }

    }
}
