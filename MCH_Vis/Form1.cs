using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCH_Vis
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            FormSizeSetting();
            
            //Pen pen_XY = new Pen(Color.Black, 2);
            //graphic.DrawEllipse(pen_XY, 200, 200, 90, 180);
            //CoordinatePlane();
        }
        Graphics graphic;
        /// <summary>
        /// Настройка размеров формы.
        /// </summary>
        private void FormSizeSetting()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            Size = new Size(w, h);
        }

        /// <summary>
        /// Отрисовка координатной плоскости.
        /// </summary>
        private void CoordinatePlane()
        {
            
            //Pen pen_xy = new Pen(Color.Gray, 1);
            //int d = 10000;
            //int number = 0; // Переменная для построения цифр на промежутках осей
            //Point point_ox1 = new Point(0, 494); // Точка нужная для отрисовки оси X
            //Point point_ox2 = new Point(10000, 494); // Точка нужная для отрисовки оси X (такая большая асцисса для больших мониторов)
            //Point point_oy1 = new Point(960, 0); // Точка нужная для отрисовки оси Y
            //Point point_oy2 = new Point(960, 10000); // Точка нужная для отрисовки оси Y (такая большая ордината для больших мониторов)
            //graphic.DrawLine(pen_XY, point_ox1, point_ox2); // Рисуем ось X
            //graphic.DrawLine(pen_XY, point_oy1, point_oy2); // Рисуем ось Y

            //for (int i = 0; i < d; i++) // Цикл который прорисовывает оси, промежутки, разметки на этих промежутках
            //{
            //    if (i % 20 == 0) // Проверям прошло ли 20 пикселей для того чтобы промежутки нормально отображались и не отрисовывались перекрывая друг друга
            //    {
            //        Point point_OX1 = new Point(i, 484); // Точка для отрисовки линии, которая служит для пометок на оси X
            //        Point point_OX2 = new Point(i, 504); // Точка для отрисовки линии, которая служит для пометок на оси X
            //        graphic.DrawLine(pen_xy, point_OX1, point_OX2); // Рисуем пометки оси X

            //        Point point_OY1 = new Point(950, i + 13); // Точка для отрисовки линии, которая служит для пометок на оси Y
            //        Point point_OY2 = new Point(970, i + 13); // Точка для отрисовки линии, которая служит для пометок на оси Y
            //        graphic.DrawLine(pen_xy, point_OY1, point_OY2); // Рисуем пометки оси Y

            //        number += 1; // Увеличиваем число, которое показывает промежутки

            //        string number_plus = number.ToString(); // Переводим из int в string для отрисовки в качестве положительного посчета промежутка
            //        string number_minus = "-" + number.ToString(); // Переводим из int в string для отрисовки в качестве отрицательного посчета промежутка

            //        graphic.DrawString(number_plus, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(973 + i, 464)); // Рисуем положительные пометки оси X
            //        graphic.DrawString(number_minus, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(930 - i, 504)); // Рисуем отрицательные пометки оси X
            //        graphic.DrawString(number_plus, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(930, 464 - i)); // Рисуем положительные пометки оси Y
            //        graphic.DrawString(number_minus, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(975, 506 + i)); // Рисуем отрицательные пометки оси Y
            //    }
            //}
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphic = pictureBox1.CreateGraphics();
            graphic.Clear(Color.White);
            Pen pen_XY = new Pen(Color.Black, 3f);
            graphic.DrawEllipse(Pens.Black, 20, 20, 200, 300);
            //CoordinatePlane();
        }
    }
}
