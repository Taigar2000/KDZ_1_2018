namespace KDZ_1
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
            this.pictureBox_fractal = new System.Windows.Forms.PictureBox();
            this.comboBox_type_of_fractal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_start_color = new System.Windows.Forms.ComboBox();
            this.comboBox_end_color = new System.Windows.Forms.ComboBox();
            this.checkBox_buffer = new System.Windows.Forms.CheckBox();
            this.textBox_dspace = new System.Windows.Forms.TextBox();
            this.label_dspace = new System.Windows.Forms.Label();
            this.textBox_max_depth_of_rec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SetStartColor = new System.Windows.Forms.Button();
            this.SetEndColor = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overAllWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fractal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_fractal
            // 
            this.pictureBox_fractal.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox_fractal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_fractal.Location = new System.Drawing.Point(0, 24);
            this.pictureBox_fractal.Name = "pictureBox_fractal";
            this.pictureBox_fractal.Size = new System.Drawing.Size(1129, 571);
            this.pictureBox_fractal.TabIndex = 0;
            this.pictureBox_fractal.TabStop = false;
            this.pictureBox_fractal.Visible = false;
            // 
            // comboBox_type_of_fractal
            // 
            this.comboBox_type_of_fractal.DisplayMember = "3";
            this.comboBox_type_of_fractal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type_of_fractal.FormattingEnabled = true;
            this.comboBox_type_of_fractal.Items.AddRange(new object[] {
            "Кривая Гильберта",
            "С-Кривая Леви",
            "Множество Кантора"});
            this.comboBox_type_of_fractal.Location = new System.Drawing.Point(2, 79);
            this.comboBox_type_of_fractal.Name = "comboBox_type_of_fractal";
            this.comboBox_type_of_fractal.Size = new System.Drawing.Size(234, 21);
            this.comboBox_type_of_fractal.TabIndex = 1;
            this.comboBox_type_of_fractal.ValueMember = "3";
            this.comboBox_type_of_fractal.SelectedIndexChanged += new System.EventHandler(this.comboBox_fractal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип фрактала";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 71);
            this.button1.TabIndex = 3;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 10571);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Начальный цвет";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Конечный цвет";
            this.label3.Visible = false;
            // 
            // comboBox_start_color
            // 
            this.comboBox_start_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_start_color.FormattingEnabled = true;
            this.comboBox_start_color.Items.AddRange(new object[] {
            "Красный",
            "Зелёный",
            "Синий"});
            this.comboBox_start_color.Location = new System.Drawing.Point(0, 136);
            this.comboBox_start_color.Name = "comboBox_start_color";
            this.comboBox_start_color.Size = new System.Drawing.Size(236, 21);
            this.comboBox_start_color.TabIndex = 5;
            this.comboBox_start_color.Visible = false;
            // 
            // comboBox_end_color
            // 
            this.comboBox_end_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_end_color.Items.AddRange(new object[] {
            "Красный",
            "Зелёный",
            "Синий"});
            this.comboBox_end_color.Location = new System.Drawing.Point(0, 189);
            this.comboBox_end_color.Name = "comboBox_end_color";
            this.comboBox_end_color.Size = new System.Drawing.Size(236, 21);
            this.comboBox_end_color.TabIndex = 7;
            this.comboBox_end_color.Visible = false;
            // 
            // checkBox_buffer
            // 
            this.checkBox_buffer.AutoSize = true;
            this.checkBox_buffer.BackColor = System.Drawing.Color.White;
            this.checkBox_buffer.Checked = true;
            this.checkBox_buffer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_buffer.Location = new System.Drawing.Point(12, 204);
            this.checkBox_buffer.Name = "checkBox_buffer";
            this.checkBox_buffer.Size = new System.Drawing.Size(139, 17);
            this.checkBox_buffer.TabIndex = 9;
            this.checkBox_buffer.Text = "Пошаговая отрисовка";
            this.checkBox_buffer.UseVisualStyleBackColor = false;
            this.checkBox_buffer.CheckedChanged += new System.EventHandler(this.checkBox_buffer_CheckedChanged);
            // 
            // textBox_dspace
            // 
            this.textBox_dspace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_dspace.Location = new System.Drawing.Point(0, 334);
            this.textBox_dspace.Name = "textBox_dspace";
            this.textBox_dspace.Size = new System.Drawing.Size(236, 20);
            this.textBox_dspace.TabIndex = 10;
            this.textBox_dspace.Visible = false;
            // 
            // label_dspace
            // 
            this.label_dspace.BackColor = System.Drawing.Color.White;
            this.label_dspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dspace.Location = new System.Drawing.Point(3, 311);
            this.label_dspace.Name = "label_dspace";
            this.label_dspace.Size = new System.Drawing.Size(233, 20);
            this.label_dspace.TabIndex = 11;
            this.label_dspace.Text = "Расстояние между прямыми";
            this.label_dspace.Visible = false;
            // 
            // textBox_max_depth_of_rec
            // 
            this.textBox_max_depth_of_rec.Location = new System.Drawing.Point(0, 281);
            this.textBox_max_depth_of_rec.Name = "textBox_max_depth_of_rec";
            this.textBox_max_depth_of_rec.Size = new System.Drawing.Size(236, 20);
            this.textBox_max_depth_of_rec.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Глубина рекурсии";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // SetStartColor
            // 
            this.SetStartColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetStartColor.Location = new System.Drawing.Point(0, 111);
            this.SetStartColor.Name = "SetStartColor";
            this.SetStartColor.Size = new System.Drawing.Size(236, 34);
            this.SetStartColor.TabIndex = 15;
            this.SetStartColor.Text = "Начальный цвет";
            this.SetStartColor.UseVisualStyleBackColor = true;
            this.SetStartColor.Click += new System.EventHandler(this.SetStart_Click);
            // 
            // SetEndColor
            // 
            this.SetEndColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetEndColor.Location = new System.Drawing.Point(0, 151);
            this.SetEndColor.Name = "SetEndColor";
            this.SetEndColor.Size = new System.Drawing.Size(236, 34);
            this.SetEndColor.TabIndex = 16;
            this.SetEndColor.Text = "Конечный цвет";
            this.SetEndColor.UseVisualStyleBackColor = true;
            this.SetEndColor.Click += new System.EventHandler(this.SetEndColor_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1129, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem2,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.loadToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Save As";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Save As (old interfeise)";
            this.saveToolStripMenuItem.Visible = false;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Visible = false;
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Visible = false;
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overAllWindowsToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // overAllWindowsToolStripMenuItem
            // 
            this.overAllWindowsToolStripMenuItem.Checked = true;
            this.overAllWindowsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overAllWindowsToolStripMenuItem.Name = "overAllWindowsToolStripMenuItem";
            this.overAllWindowsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.overAllWindowsToolStripMenuItem.Text = "Over all windows";
            this.overAllWindowsToolStripMenuItem.Click += new System.EventHandler(this.overAllWindowsToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 227);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(199, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Отрисовывать все шаги рекурсии";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Масштаб: ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(142, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 439);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "1";
            // 
            // saveToolStripMenuItem2
            // 
            this.saveToolStripMenuItem2.Name = "saveToolStripMenuItem2";
            this.saveToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem2.Text = "Save";
            this.saveToolStripMenuItem2.Click += new System.EventHandler(this.saveToolStripMenuItem2_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 595);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SetEndColor);
            this.Controls.Add(this.SetStartColor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_max_depth_of_rec);
            this.Controls.Add(this.label_dspace);
            this.Controls.Add(this.textBox_dspace);
            this.Controls.Add(this.checkBox_buffer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_type_of_fractal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_fractal);
            this.Controls.Add(this.comboBox_start_color);
            this.Controls.Add(this.comboBox_end_color);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(286, 501);
            this.Name = "Form1";
            this.Text = "Приложение для построения фракталов";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fractal_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fractal_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fractal_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fractal_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fractal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_fractal;
        private System.Windows.Forms.ComboBox comboBox_type_of_fractal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_start_color;
        private System.Windows.Forms.ComboBox comboBox_end_color;
        private System.Windows.Forms.CheckBox checkBox_buffer;
        private System.Windows.Forms.TextBox textBox_dspace;
        private System.Windows.Forms.Label label_dspace;
        private System.Windows.Forms.TextBox textBox_max_depth_of_rec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SetStartColor;
        private System.Windows.Forms.Button SetEndColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overAllWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

