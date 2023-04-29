using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputationalGeometry;

namespace MCH_Vis
{
    public partial class Form1 : Form
    {
        Graphics graphic;
        List<MyPoint> myPoints;
        int center_X;
        int center_Y;
        public Form1()
        {
            InitializeComponent();
            FormSizeSetting();
            graphic = pictureBox1.CreateGraphics();
            myPoints = new List<MyPoint>()
            {
                new MyPoint(1,1),
                new MyPoint(6,1),
                new MyPoint(4,2),
                new MyPoint(9,2),
                new MyPoint(3,4),
                new MyPoint(8,4),
                new MyPoint(5,5),
                new MyPoint(10,5),
                new MyPoint(2,6),
                new MyPoint(6,7),
                new MyPoint(6,-6),
                new MyPoint(0,0),
                new MyPoint(0,-5)
            };
            pointsList.Items.AddRange(myPoints.ToArray());
            mchList.Items.Add(myPoints[0]);
            center_X = (pictureBox1.Width / 2) - 9;//960
            center_Y = (pictureBox1.Height / 2) - 6;//494
        }

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
            Pen pen_XY = new Pen(Color.Black, 2f);
            Pen pen_xy = new Pen(Color.Black, 1f);
            int d = 10000;
            int number = 0; // Переменная для построения цифр на промежутках осей
            Point point_ox1 = new Point(0, center_Y); // Точка нужная для отрисовки оси X
            Point point_ox2 = new Point(pictureBox1.Width, center_Y); // Точка нужная для отрисовки оси X (такая большая асцисса для больших мониторов)
            Point point_oy1 = new Point(center_X, 0); // Точка нужная для отрисовки оси Y
            Point point_oy2 = new Point(center_X, pictureBox1.Height); // Точка нужная для отрисовки оси Y (такая большая ордината для больших мониторов)
            graphic.DrawLine(pen_XY, point_ox1, point_ox2); // Рисуем ось X
            graphic.DrawLine(pen_XY, point_oy1, point_oy2); // Рисуем ось Y

            for (int i = 0; i < d; i++) // Цикл который прорисовывает оси, промежутки, разметки на этих промежутках
            {
                if (i % 20 == 0) // Проверям прошло ли 20 пикселей для того чтобы промежутки нормально отображались и не отрисовывались перекрывая друг друга
                {
                    Point point_OX1 = new Point(i, center_Y - 4); // Точка для отрисовки линии, которая служит для пометок на оси X
                    Point point_OX2 = new Point(i, center_Y + 4); // Точка для отрисовки линии, которая служит для пометок на оси X
                    graphic.DrawLine(pen_xy, point_OX1, point_OX2); // Рисуем пометки оси X

                    Point point_OY1 = new Point(center_X - 4, i + 13); // Точка для отрисовки линии, которая служит для пометок на оси Y
                    Point point_OY2 = new Point(center_X + 4, i + 13); // Точка для отрисовки линии, которая служит для пометок на оси Y
                    graphic.DrawLine(pen_xy, point_OY1, point_OY2); // Рисуем пометки оси Y

                    number += 1; // Увеличиваем число, которое показывает промежутки

                    string number_plus = number.ToString(); // Переводим из int в string для отрисовки в качестве положительного посчета промежутка
                    string number_minus = "-" + number.ToString(); // Переводим из int в string для отрисовки в качестве отрицательного посчета промежутка
                    
                    graphic.DrawString(number_plus, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), new Point(center_X + 15 + i, center_Y - 18)); // Рисуем положительные пометки оси X
                    graphic.DrawString(number_minus, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), new Point(center_X - 30 - i, center_Y + 10)); // Рисуем отрицательные пометки оси X
                    graphic.DrawString(number_plus, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), new Point(center_X - 25, center_Y - 30 - i)); // Рисуем положительные пометки оси Y
                    graphic.DrawString(number_minus, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), new Point(center_X + 10, center_Y + 10 + i)); // Рисуем отрицательные пометки оси Y
                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                CoordinatePlane();
        }

        /// <summary>
        /// Добавление точки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPoint_Click(object sender, EventArgs e)
        {
            //обработать повторение точек!!!!!!!!!!!!
            try
            {
                if (xValue.Text == "" || yValue.Text == "")
                {
                    MessageBox.Show("Заполните значения координат X, Y.", "Предупреждение");
                    return;
                }
                int x = Convert.ToInt32(xValue.Text);//18
                int y = Convert.ToInt32(yValue.Text);//14
                if (Math.Abs(x) > 16 || Math.Abs(y) > 14)
                {
                    MessageBox.Show("Выход за допустимое значение координат.", "Предупреждение");
                    return;
                }
                MyPoint p = new MyPoint(x, y);
                pointsList.Items.Add(p);
                myPoints.Add(p);
                clearXY();
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Неверный ввод данных.", "Предупреждение");
                clearXY();
                return;
            }
        }

        /// <summary>
        /// Очистка полей для ввода координат.
        /// </summary>
        private void clearXY()
        {
            xValue.Text = "";
            yValue.Text = "";
        }

        /// <summary>
        /// Удаление точки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delPoint_Click(object sender, EventArgs e)
        {
            if (pointsList.SelectedItem == null)
                return;
            int delPoint = pointsList.SelectedIndex;
            myPoints.RemoveAt(delPoint);
            pointsList.Items.RemoveAt(delPoint);
        }

        private void algolTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = algolTask.SelectedIndex;
            switch(index)
            {
                case (0):
                    GrahamTask();
                    break;
                case (1):
                    break;
                case (2):
                    break;
                case (3):
                    break;
            }
        }

        /// <summary>
        /// отрисовка точек на графике.
        /// </summary>
        private void PointDrawing()
        {
            foreach(MyPoint point in myPoints)
            {
                MyPoint pointGrafics = CalculCoordinate(point);
                graphic.FillEllipse(Brushes.Blue, (int)pointGrafics.X, (int)pointGrafics.Y, 6, 6);
            }
        }

        private MyPoint CalculCoordinate(MyPoint point)
        {
            if(point.X>=0 && point.Y>=0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y - (int)point.Y * 20  - 3;
                return new MyPoint(x,y);
            }
            if (point.X >= 0 && point.Y <= 0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y + (int)point.Y * (-20) - 3;
                return new MyPoint(x, y);
            }
            if (point.X >= 0 && point.Y >= 0)//доделать
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y - (int)point.Y * 20 - 3;
                return new MyPoint(x, y);
            }
            if (point.X >= 0 && point.Y >= 0)//доделать
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y - (int)point.Y * 20 - 3;
                return new MyPoint(x, y);
            }
            return new MyPoint();
        }

        /// <summary>
        /// Построениее минимальной выпуклой оболочки при помощи алгоритма Грэхема.
        /// </summary>
        private void GrahamTask()
        {
            PointDrawing();
            MCH mCH = new MCH(myPoints);
            
            mCH.Graham();
        }
    }
}
