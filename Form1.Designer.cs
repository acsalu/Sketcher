namespace Sketcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ellipseTool = new System.Windows.Forms.PictureBox();
            this.rectangleTool = new System.Windows.Forms.PictureBox();
            this.pencilTool = new System.Windows.Forms.PictureBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pencilTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ellipseTool
            // 
            this.ellipseTool.Image = global::Sketcher.Properties.Resources.btn_ellipse_normal;
            this.ellipseTool.Location = new System.Drawing.Point(124, 33);
            this.ellipseTool.Name = "ellipseTool";
            this.ellipseTool.Size = new System.Drawing.Size(50, 50);
            this.ellipseTool.TabIndex = 4;
            this.ellipseTool.TabStop = false;
            this.ellipseTool.Click += new System.EventHandler(this.ellipseTool_Click_1);
            // 
            // rectangleTool
            // 
            this.rectangleTool.Image = global::Sketcher.Properties.Resources.btn_rectangle_normal;
            this.rectangleTool.Location = new System.Drawing.Point(68, 33);
            this.rectangleTool.Name = "rectangleTool";
            this.rectangleTool.Size = new System.Drawing.Size(50, 50);
            this.rectangleTool.TabIndex = 3;
            this.rectangleTool.TabStop = false;
            this.rectangleTool.Click += new System.EventHandler(this.rectangleTool_Click_1);
            // 
            // pencilTool
            // 
            this.pencilTool.Image = global::Sketcher.Properties.Resources.btn_pencil_normal;
            this.pencilTool.Location = new System.Drawing.Point(12, 33);
            this.pencilTool.Name = "pencilTool";
            this.pencilTool.Size = new System.Drawing.Size(50, 50);
            this.pencilTool.TabIndex = 2;
            this.pencilTool.TabStop = false;
            this.pencilTool.Click += new System.EventHandler(this.pencilTool_Click_1);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Location = new System.Drawing.Point(12, 89);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1170, 514);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUP);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 610);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1194, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 632);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ellipseTool);
            this.Controls.Add(this.rectangleTool);
            this.Controls.Add(this.pencilTool);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Sketcher - Untitled";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ellipseTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pencilTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.PictureBox pencilTool;
        private System.Windows.Forms.PictureBox rectangleTool;
        private System.Windows.Forms.PictureBox ellipseTool;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

