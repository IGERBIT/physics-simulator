namespace PhysicsSimulator
{
    partial class SimulatedForm
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
            this.components = new System.ComponentModel.Container();
            this.values = new System.Windows.Forms.GroupBox();
            this.start = new System.Windows.Forms.Button();
            this.inerface = new System.Windows.Forms.Panel();
            this.visual = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // values
            // 
            this.values.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.values.BackColor = System.Drawing.SystemColors.Control;
            this.values.Controls.Add(this.start);
            this.values.Controls.Add(this.inerface);
            this.values.Location = new System.Drawing.Point(403, 12);
            this.values.Name = "values";
            this.values.Size = new System.Drawing.Size(319, 459);
            this.values.TabIndex = 0;
            this.values.TabStop = false;
            this.values.Text = "Параметры";
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(177, 400);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(136, 53);
            this.start.TabIndex = 2;
            this.start.Tag = "True";
            this.start.Text = "Стоп";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // inerface
            // 
            this.inerface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inerface.AutoScroll = true;
            this.inerface.BackColor = System.Drawing.SystemColors.Control;
            this.inerface.Location = new System.Drawing.Point(6, 19);
            this.inerface.Name = "inerface";
            this.inerface.Size = new System.Drawing.Size(307, 381);
            this.inerface.TabIndex = 0;
            // 
            // visual
            // 
            this.visual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visual.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.visual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.visual.Location = new System.Drawing.Point(12, 27);
            this.visual.Name = "visual";
            this.visual.Size = new System.Drawing.Size(385, 400);
            this.visual.TabIndex = 1;
            this.visual.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 31);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Debug включён",
            "Debug выключен"});
            this.toolStripComboBox1.MergeIndex = 1;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // SimulatedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 483);
            this.Controls.Add(this.visual);
            this.Controls.Add(this.values);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimulatedForm";
            this.Text = "Симуляция метода";
            this.Load += new System.EventHandler(this.Resizeing);
            this.SizeChanged += new System.EventHandler(this.Resizeing);
            this.values.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visual)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox values;
        private System.Windows.Forms.PictureBox visual;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Panel inerface;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}