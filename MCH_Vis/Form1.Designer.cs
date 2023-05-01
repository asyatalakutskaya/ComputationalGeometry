
namespace MCH_Vis
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yValue = new System.Windows.Forms.TextBox();
            this.xValue = new System.Windows.Forms.TextBox();
            this.pointsList = new System.Windows.Forms.ListBox();
            this.clearPoint = new System.Windows.Forms.Button();
            this.delPoint = new System.Windows.Forms.Button();
            this.addPoint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mchList = new System.Windows.Forms.ListBox();
            this.clearGraphic = new System.Windows.Forms.Button();
            this.algolTask = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(471, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(471, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // yValue
            // 
            this.yValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yValue.Location = new System.Drawing.Point(517, 99);
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(120, 38);
            this.yValue.TabIndex = 2;
            // 
            // xValue
            // 
            this.xValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xValue.Location = new System.Drawing.Point(517, 36);
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(120, 38);
            this.xValue.TabIndex = 3;
            // 
            // pointsList
            // 
            this.pointsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsList.FormattingEnabled = true;
            this.pointsList.ItemHeight = 31;
            this.pointsList.Location = new System.Drawing.Point(489, 239);
            this.pointsList.Name = "pointsList";
            this.pointsList.Size = new System.Drawing.Size(320, 376);
            this.pointsList.TabIndex = 4;
            // 
            // clearPoint
            // 
            this.clearPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearPoint.Location = new System.Drawing.Point(921, 29);
            this.clearPoint.Name = "clearPoint";
            this.clearPoint.Size = new System.Drawing.Size(264, 50);
            this.clearPoint.TabIndex = 6;
            this.clearPoint.Text = "Очистить точки";
            this.clearPoint.UseVisualStyleBackColor = true;
            this.clearPoint.Click += new System.EventHandler(this.clearPoint_Click);
            // 
            // delPoint
            // 
            this.delPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delPoint.Location = new System.Drawing.Point(660, 92);
            this.delPoint.Name = "delPoint";
            this.delPoint.Size = new System.Drawing.Size(245, 50);
            this.delPoint.TabIndex = 8;
            this.delPoint.Text = "Удалить точку";
            this.delPoint.UseVisualStyleBackColor = true;
            this.delPoint.Click += new System.EventHandler(this.delPoint_Click);
            // 
            // addPoint
            // 
            this.addPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPoint.Location = new System.Drawing.Point(660, 29);
            this.addPoint.Name = "addPoint";
            this.addPoint.Size = new System.Drawing.Size(245, 50);
            this.addPoint.TabIndex = 7;
            this.addPoint.Text = "Добавить точку";
            this.addPoint.UseVisualStyleBackColor = true;
            this.addPoint.Click += new System.EventHandler(this.addPoint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 593);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // mchList
            // 
            this.mchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mchList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mchList.FormattingEnabled = true;
            this.mchList.ItemHeight = 31;
            this.mchList.Location = new System.Drawing.Point(854, 239);
            this.mchList.Name = "mchList";
            this.mchList.Size = new System.Drawing.Size(320, 376);
            this.mchList.TabIndex = 10;
            // 
            // clearGraphic
            // 
            this.clearGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearGraphic.Location = new System.Drawing.Point(921, 92);
            this.clearGraphic.Name = "clearGraphic";
            this.clearGraphic.Size = new System.Drawing.Size(264, 50);
            this.clearGraphic.TabIndex = 11;
            this.clearGraphic.Text = "Очистить график";
            this.clearGraphic.UseVisualStyleBackColor = true;
            this.clearGraphic.Click += new System.EventHandler(this.clearGraphic_Click);
            // 
            // algolTask
            // 
            this.algolTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.algolTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.algolTask.FormattingEnabled = true;
            this.algolTask.Items.AddRange(new object[] {
            "Алгоритм Грэхема",
            "Алгоритма Джарвиса",
            "Алгоритм быстрой оболочки"});
            this.algolTask.Location = new System.Drawing.Point(489, 175);
            this.algolTask.Name = "algolTask";
            this.algolTask.Size = new System.Drawing.Size(685, 39);
            this.algolTask.TabIndex = 12;
            this.algolTask.SelectedIndexChanged += new System.EventHandler(this.algolTask_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1210, 632);
            this.Controls.Add(this.algolTask);
            this.Controls.Add(this.clearGraphic);
            this.Controls.Add(this.mchList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.delPoint);
            this.Controls.Add(this.addPoint);
            this.Controls.Add(this.clearPoint);
            this.Controls.Add(this.pointsList);
            this.Controls.Add(this.xValue);
            this.Controls.Add(this.yValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yValue;
        private System.Windows.Forms.TextBox xValue;
        private System.Windows.Forms.ListBox pointsList;
        private System.Windows.Forms.Button clearPoint;
        private System.Windows.Forms.Button delPoint;
        private System.Windows.Forms.Button addPoint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox mchList;
        private System.Windows.Forms.Button clearGraphic;
        private System.Windows.Forms.ComboBox algolTask;
    }
}

