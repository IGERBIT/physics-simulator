namespace PhysicsSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьМетодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setting = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьВсеНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 158);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(549, 279);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(573, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьМетодToolStripMenuItem,
            this.toolStripSeparator1,
            this.setting,
            this.сброситьВсеНастройкиToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(79, 19);
            this.toolStripMenuItem1.Text = "Настройки";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // загрузитьМетодToolStripMenuItem
            // 
            this.загрузитьМетодToolStripMenuItem.Name = "загрузитьМетодToolStripMenuItem";
            this.загрузитьМетодToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.загрузитьМетодToolStripMenuItem.Text = "Загрузить метод";
            this.загрузитьМетодToolStripMenuItem.Click += new System.EventHandler(this.загрузитьМетодToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // setting
            // 
            this.setting.MergeIndex = 0;
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(240, 22);
            this.setting.Text = "Настройки приложения";
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // сброситьВсеНастройкиToolStripMenuItem
            // 
            this.сброситьВсеНастройкиToolStripMenuItem.Name = "сброситьВсеНастройкиToolStripMenuItem";
            this.сброситьВсеНастройкиToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.сброситьВсеНастройкиToolStripMenuItem.Text = "Следующй запуск как первый";
            this.сброситьВсеНастройкиToolStripMenuItem.Click += new System.EventHandler(this.сброситьВсеНастройкиToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "PhysicsModeler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setting;
        private System.Windows.Forms.ToolStripMenuItem сброситьВсеНастройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьМетодToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

