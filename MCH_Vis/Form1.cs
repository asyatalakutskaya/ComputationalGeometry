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
        List<MyPoint> minimumCH;
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
                new MyPoint(6,7)
            };
            pointsList.Items.AddRange(myPoints.ToArray());

            center_X = (pictureBox1.Width / 2) - 9;
            center_Y = (pictureBox1.Height / 2) - 6;
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
        /// <summary>
        /// Отрисовка точки на графике.
        /// </summary>
        private void PointDrawing()
        {
            foreach (MyPoint point in myPoints)
            {
                MyPoint pointGrafics = CalculCoordinate(point);//Получили фактические координаты точки на отображаемой плоскости
                graphic.FillEllipse(Brushes.Blue, (int)pointGrafics.X, (int)pointGrafics.Y, 6, 6);//Отобразили на графике
            }
        }
        /// <summary>
        /// Пересчёт координат точки на координаты отображаемой на форме плоскости.
        /// </summary>
        /// <param name="point">Точка, для которой нужно пересчитать координаты.</param>
        /// <returns>Новые координаты точки.</returns>
        private MyPoint CalculCoordinate(MyPoint point)
        {
            if (point.X >= 0 && point.Y >= 0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y - (int)point.Y * 20 - 3;
                return new MyPoint(x, y);
            }
            if (point.X >= 0 && point.Y < 0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y + (int)point.Y * (-20) - 3;
                return new MyPoint(x, y);
            }
            if (point.X < 0 && point.Y < 0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y + (int)point.Y * (-20) - 3;
                return new MyPoint(x, y);
            }
            if (point.X < 0 && point.Y >= 0)
            {
                int x = center_X + (int)point.X * 20 - 3;
                int y = center_Y - (int)point.Y * 20 - 3;
                return new MyPoint(x, y);
            }
            return new MyPoint();
        }
        /// <summary>
        /// Очистка полей для ввода координат.
        /// </summary>
        private void clearXY()
        {
            xValue.Text = "";
            yValue.Text = "";
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
                if(myPoints.Contains(p))
                {
                    MessageBox.Show("Точка с такими координатами уже есть в списке.", "Предупреждение");
                    return;
                }
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
        /// Удаление точки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delPoint_Click(object sender, EventArgs e)
        {
            if (pointsList.SelectedItem == null)
            {
                MessageBox.Show("Для удаления точки сначала выберите её в списке.", "Предупреждение");
                return;
            }
            int delPoint = pointsList.SelectedIndex;
            myPoints.RemoveAt(delPoint);
            pointsList.Items.RemoveAt(delPoint);
        }
        private void algolTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(myPoints.Count <=3)
            {
                MessageBox.Show("Недостаточно точек для построения минимальной выпуклой оболочки.", "Предупреждение");
                return;
            }
            int index = algolTask.SelectedIndex;
            switch(index)
            {
                case (0):
                    GrahamTask();
                    break;
                case (1):
                    Jarvismarch();
                    break;
                case (2):
                    QuickHull();
                    break;
                case (3):
                    break;
            }
        }
        

        /// <summary>
        /// Построениее минимальной выпуклой оболочки при помощи алгоритма Грэхема.
        /// </summary>
        private void GrahamTask()
        {
            PointDrawing();
            MCH mCH = new MCH(myPoints);
            mCH.Graham();
            minimumCH = new List<MyPoint>();
            PrintMCHList(mCH.minCH);
            PrintMCHGrafic();
        }

        /// <summary>
        /// Построениее минимальной выпуклой оболочки при помощи алгоритма Джарвиса.
        /// </summary>
        private void Jarvismarch()
        {
            PointDrawing();
            MCH mCH = new MCH(myPoints);
            mCH.Jarvismarch();
            minimumCH = new List<MyPoint>();
            PrintMCHList(mCH.minCH);
            PrintMCHGrafic();
        }

        /// <summary>
        /// Построениее минимальной выпуклой оболочки при помощи алгоритма быстрой оболочки.
        /// </summary>
        private void QuickHull()
        {
            PointDrawing();
            MCH mCH = new MCH(myPoints);
            mCH.printHull();
            minimumCH = new List<MyPoint>();
            PrintMCHList(mCH.minCH);
            PrintMCHGrafic();
        }

        /// <summary>
        /// Сохранение построенной МВО в переменной minimumCH и вывод точек, образующих МВО на форму.
        /// </summary>
        /// <param name="minCH"></param>
        private void PrintMCHList(List<int> minCH)
        {
            foreach (int index in minCH)
                minimumCH.Add(myPoints[index]);
            mchList.Items.Clear();
            mchList.Items.AddRange(minimumCH.ToArray());
        }

        /// <summary>
        /// Построение минимальной выпуклой оболочки на графике.
        /// </summary>
        private void PrintMCHGrafic()
        {
            Pen pen = new Pen(Color.Red, 2f);
            MyPoint point1 = CalculCoordinate(minimumCH[0]);
            MyPoint point2 = CalculCoordinate(minimumCH[minimumCH.Count - 1]);
            graphic.DrawLine(pen, (float)point1.X + 3, (float)point1.Y + 3, (float)point2.X + 3, (float)point2.Y + 3);
            for(int i = 0; i<minimumCH.Count-1; ++i)
            {
                point1 = CalculCoordinate(minimumCH[i]);
                point2 = CalculCoordinate(minimumCH[i+1]);
                graphic.DrawLine(pen, (float)point1.X + 3, (float)point1.Y + 3, (float)point2.X + 3, (float)point2.Y + 3);
            }
        }

        private void clearPoint_Click(object sender, EventArgs e)
        {
            pointsList.Items.Clear();
            mchList.Items.Clear();
            if(myPoints!=null)
                myPoints.Clear();
            if(minimumCH!=null)
                minimumCH.Clear();
            ClearGrafic();
        }

        private void clearGraphic_Click(object sender, EventArgs e)
        {
            ClearGrafic();
        }

        private void ClearGrafic()
        {
            graphic.Clear(Color.White);
            CoordinatePlane();
        }
    }
}
