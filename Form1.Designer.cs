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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSketcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pencilTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aBOUTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1194, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "FILE";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSketcherToolStripMenuItem});
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutSketcherToolStripMenuItem
            // 
            this.aboutSketcherToolStripMenuItem.Name = "aboutSketcherToolStripMenuItem";
            this.aboutSketcherToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutSketcherToolStripMenuItem.Text = "About Sketcher";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 632);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ellipseTool);
            this.Controls.Add(this.rectangleTool);
            this.Controls.Add(this.pencilTool);
            this.Controls.Add(this.canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sketcher - Untitled";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ellipseTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pencilTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSketcherToolStripMenuItem;

    }
}

