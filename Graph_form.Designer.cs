namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.coord_y = new System.Windows.Forms.TextBox();
            this.coord_x = new System.Windows.Forms.TextBox();
            this.add_point = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.point_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.set_path = new System.Windows.Forms.Button();
            this.Lines = new System.Windows.Forms.Button();
            this.Points = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hint = new System.Windows.Forms.Label();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.point_name_man = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВФайлToolStripMenuItem,
            this.загрузитьИзФайлаToolStripMenuItem,
            this.сохранитьВБДToolStripMenuItem,
            this.загрузитьИзБДToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьВФайлToolStripMenuItem
            // 
            this.сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
            this.сохранитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.сохранитьВФайлToolStripMenuItem.Text = "Сохранить в файл";
            this.сохранитьВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВФайлToolStripMenuItem_Click);
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            this.загрузитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзФайлаToolStripMenuItem_Click);
            // 
            // сохранитьВБДToolStripMenuItem
            // 
            this.сохранитьВБДToolStripMenuItem.Name = "сохранитьВБДToolStripMenuItem";
            this.сохранитьВБДToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.сохранитьВБДToolStripMenuItem.Text = "Сохранить в БД";
            this.сохранитьВБДToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВБДToolStripMenuItem_Click);
            // 
            // загрузитьИзБДToolStripMenuItem
            // 
            this.загрузитьИзБДToolStripMenuItem.Name = "загрузитьИзБДToolStripMenuItem";
            this.загрузитьИзБДToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.загрузитьИзБДToolStripMenuItem.Text = "Загрузить из БД";
            this.загрузитьИзБДToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзБДToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.calc);
            this.panel1.Controls.Add(this.set_path);
            this.panel1.Controls.Add(this.Lines);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 534);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.coord_y);
            this.panel3.Controls.Add(this.coord_x);
            this.panel3.Controls.Add(this.add_point);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.point_name);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(149, 111);
            this.panel3.TabIndex = 4;
            // 
            // coord_y
            // 
            this.coord_y.Location = new System.Drawing.Point(109, 55);
            this.coord_y.MaxLength = 3;
            this.coord_y.Name = "coord_y";
            this.coord_y.Size = new System.Drawing.Size(33, 20);
            this.coord_y.TabIndex = 9;
            this.coord_y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.coord_x_KeyPress);
            // 
            // coord_x
            // 
            this.coord_x.Location = new System.Drawing.Point(109, 29);
            this.coord_x.MaxLength = 3;
            this.coord_x.Name = "coord_x";
            this.coord_x.Size = new System.Drawing.Size(33, 20);
            this.coord_x.TabIndex = 8;
            this.coord_x.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.coord_x_KeyPress);
            // 
            // add_point
            // 
            this.add_point.Location = new System.Drawing.Point(4, 81);
            this.add_point.Name = "add_point";
            this.add_point.Size = new System.Drawing.Size(138, 23);
            this.add_point.TabIndex = 7;
            this.add_point.Text = "Добавить вершину";
            this.toolTip1.SetToolTip(this.add_point, "Добавляет вершину графа с указанным именем и кординатами");
            this.add_point.UseVisualStyleBackColor = true;
            this.add_point.Click += new System.EventHandler(this.add_point_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // point_name
            // 
            this.point_name.Location = new System.Drawing.Point(71, 3);
            this.point_name.MaxLength = 5;
            this.point_name.Name = "point_name";
            this.point_name.Size = new System.Drawing.Size(73, 20);
            this.point_name.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Координаты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(3, 243);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(149, 23);
            this.calc.TabIndex = 3;
            this.calc.Text = "Рассчитать";
            this.toolTip1.SetToolTip(this.calc, "Рассчитать и отобразить кратчайший путь между указанными вершинами графа");
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // set_path
            // 
            this.set_path.Location = new System.Drawing.Point(3, 214);
            this.set_path.Name = "set_path";
            this.set_path.Size = new System.Drawing.Size(149, 23);
            this.set_path.TabIndex = 2;
            this.set_path.Text = "Короткий путь";
            this.toolTip1.SetToolTip(this.set_path, "Отметить вершины графа, между которыми нужно найти кратчайший путь");
            this.set_path.UseVisualStyleBackColor = true;
            this.set_path.Click += new System.EventHandler(this.path_Click);
            // 
            // Lines
            // 
            this.Lines.Location = new System.Drawing.Point(3, 185);
            this.Lines.Name = "Lines";
            this.Lines.Size = new System.Drawing.Size(149, 23);
            this.Lines.TabIndex = 1;
            this.Lines.Text = "Грани";
            this.toolTip1.SetToolTip(this.Lines, "Активировать режим создания/удаления граней графа");
            this.Lines.UseVisualStyleBackColor = true;
            this.Lines.Click += new System.EventHandler(this.Lines_Click);
            // 
            // Points
            // 
            this.Points.Location = new System.Drawing.Point(3, 29);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(138, 23);
            this.Points.TabIndex = 0;
            this.Points.Text = "Вершины по клику";
            this.toolTip1.SetToolTip(this.Points, "Активирует режим, при котором вершины графа будут создаваться при каждом клике по" +
                    " полю");
            this.Points.UseVisualStyleBackColor = true;
            this.Points.Click += new System.EventHandler(this.Points_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.hint);
            this.panel2.Location = new System.Drawing.Point(175, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 17);
            this.panel2.TabIndex = 2;
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Location = new System.Drawing.Point(3, 0);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(242, 13);
            this.hint.TabIndex = 0;
            this.hint.Text = "Для начала работы создайте вершины графа.";
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(175, 50);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(605, 511);
            this.Canvas.TabIndex = 3;
            this.Canvas.TabStop = false;
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.point_name_man);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.Points);
            this.panel4.Location = new System.Drawing.Point(3, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(149, 58);
            this.panel4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Имя";
            // 
            // point_name_man
            // 
            this.point_name_man.Location = new System.Drawing.Point(72, 3);
            this.point_name_man.MaxLength = 5;
            this.point_name_man.Name = "point_name_man";
            this.point_name_man.Size = new System.Drawing.Size(70, 20);
            this.point_name_man.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Test-Graph";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Lines;
        private System.Windows.Forms.Button Points;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label hint;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button set_path;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button add_point;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox point_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox coord_y;
        private System.Windows.Forms.TextBox coord_x;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox point_name_man;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

