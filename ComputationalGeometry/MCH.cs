using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalGeometry
{
    /// <summary>
    /// Класс, реализующий точку на плоскости (т.е. координаты x и y).
    /// </summary>
    public class MyPoint
    {
        /// <summary>
        /// Координата по оси OX.
        /// </summary>
        public double X { get; private set; }
        /// <summary>
        /// Координата по оси OY.
        /// </summary>
        public double Y { get; private set; }
        /// <summary>
        /// Инициализирует новый экземпляр класса Point, который является пустым и имеет начальные значения координат равными 0.
        /// </summary>
        public MyPoint()
        {
            X = 0;
            Y = 0;
        }
        public MyPoint(MyPoint p)
        {
            X = p.X;
            Y = p.Y;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса Point.
        /// </summary>
        /// <param name="x">Координата по оси OX.</param>
        /// <param name="y">Координата по оси OY.</param>
        public MyPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            //Если не проверить на null объект other, то other.GetType() может выбросить //NullReferenceException.            
            if (obj == null)
                return false;
            //Если ссылки указывают на один и тот же адрес, то их идентичность гарантирована.
            if (object.ReferenceEquals(this, obj))
                return true;
            if (obj is MyPoint point) 
                return X == point.X && Y == point.Y;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }

    /// <summary>
    /// Класс, реализующий алгоритмы построения минимальных выпуклых оболочек.
    /// </summary>
    public class MCH
    {
        /// <summary>
        /// Количество точек в множестве.
        /// </summary>
        private int N;
        /// <summary>
        /// Множество точек.
        /// </summary>
        private List<MyPoint> Points;
        /// <summary>
        /// Минимальная выпуклая оболочка.
        /// </summary>
        public List<int> minCH { get; private set; }

        public MCH()
        {
            Points = new List<MyPoint>();
            N = 0;
        }
        public MCH(List<MyPoint> p)
        {
            Points = p;
            N = Points.Count;
        }

        /// <summary>
        /// Алгоритм Грэхема.
        /// </summary>
        public void Graham()
        {
            //Нельзя построить минимальную выпуклую оболочку
            if (N < 3)
                return;
            List<int> P = new List<int>();//список номеров точек
            for (int i = 0; i < N; ++i)
                P.Add(i);
            //Выбор стартовой точки(самая левая) и перестановка её номера в начало
            for (int i = 1; i < N; ++i)
                if (Points[P[i]].X < Points[P[0]].X) //если P[i]-ая точка лежит левее P[0]-ой точки
                    Swap(P, i, 0); //меняем местами номера этих точек 
            for (int i = 2; i < N; ++i) //сортировка вставкой
            {
                int j = i;
                while (j > 1 && (Rotate(Points[P[0]], Points[P[j - 1]], Points[P[j]]) < 0))
                {
                    Swap(P, j, j - 1);
                    j -= 1;
                }
            }
            minCH = new List<int>() { P[0], P[1] };//создаем стек
            for (int i = 2; i < N; ++i)
            {
                while (Rotate(Points[minCH[minCH.Count - 2]], Points[minCH[minCH.Count - 1]], Points[P[i]]) < 0)
                    minCH.RemoveAt(minCH.Count - 1); //pop(S)
                minCH.Add(P[i]); //push(S,P[i])
            }
        }

        /// <summary>
        /// Алгоритм Джарвиса.
        /// </summary>
        public void Jarvismarch()
        {
            //Нельзя построить минимальную выпуклую оболочку
            if (N < 3)
                return;
            List<int> P = new List<int>();//список номеров точек
            for (int i = 0; i < N; ++i)
                P.Add(i);
            for (int i = 1; i < N; ++i)
                if (Points[P[i]].X < Points[P[0]].X)
                    Swap(P, P[i], P[0]);  //swap
            minCH = new List<int>() { P[0] };
            P.RemoveAt(0);//удаляем элеменнт из начала и сохраняем его в конце
            P.Add(minCH[0]);
            while (true)
            {
                int right = 0;
                for (int i = 1; i < P.Count; ++i)
                    if (Rotate(Points[minCH[minCH.Count - 1]], Points[P[right]], Points[P[i]]) < 0)
                        right = i;
                if (P[right] == minCH[0])
                    break;
                else
                {
                    minCH.Add(P[right]);
                    P.RemoveAt(right);
                }
            }
        }

        /// <summary>
        /// Алгоритм быстрой оболочки
        /// </summary>
        public void printHull()
        {
            //Нельзя построить минимальную выпуклую оболочку
            if (N < 3)
                return;
            //Самая левая и самая правая точки
            int leftPoint = 0, rightPoint = 0;
            for (int i = 1; i < N; i++)
            {
                if (Points[i].X < Points[leftPoint].X)
                    leftPoint = i;
                if (Points[i].X > Points[rightPoint].X)
                    rightPoint = i;
            }
            minCH = new List<int>();
            //Рекурсивный поиск крайних точек
            quickHull(Points[leftPoint], Points[rightPoint], 1);
            quickHull(Points[leftPoint], Points[rightPoint], -1);
            SortMCH();
        }

        /// <summary>
        /// Сортировка точек в порядке их "левоты" от стартовой точки.
        /// </summary>
        private void SortMCH()
        {
            for (int i = 1; i < minCH.Count; ++i)
                if (Points[minCH[i]].X < Points[minCH[0]].X) //если P[i]-ая точка лежит левее P[0]-ой точки
                    Swap(minCH, i, 0); //меняем местами номера этих точек 
            for (int i = 2; i < minCH.Count; ++i) //сортировка вставкой
            {
                int j = i;
                while (j > 1 && (Rotate(Points[minCH[0]], Points[minCH[j - 1]], Points[minCH[j]]) < 0))
                {
                    Swap(minCH, j, j - 1);
                    j -= 1;
                }
            }
        }

        private void quickHull(MyPoint p1, MyPoint p2, int side)
        {
            int ind = -1;
            double max_dist = 0;
            //Нахождение точки, максимально удаленной от прямой, а также на указанной стороне относительно прямой.
            for (int i = 0; i < N; i++)
            {
                double temp = lineDist(p1, p2, Points[i]);
                if (Rotate(p1, p2, Points[i]) == side && temp > max_dist)
                {
                    ind = i;
                    max_dist = temp;
                }
            }
            //Если точка не найдена, то добавляем конечные точки L к выпуклой оболочке.
            if (ind == -1)
            {
                int index1 = Points.IndexOf(p1);
                if (!minCH.Contains(index1))
                    minCH.Add(Points.IndexOf(p1));
                int index2 = Points.IndexOf(p2);
                if (!minCH.Contains(index2)) 
                    minCH.Add(Points.IndexOf(p2));
                return;
            }
            // Recur for the two parts divided by a[ind]
            quickHull(Points[ind], p1, -Rotate(Points[ind], p1, p2));
            quickHull(Points[ind], p2, -Rotate(Points[ind], p2, p1));
        }

        /// <summary>
        /// Расстояние от точки до прямой.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private double lineDist(MyPoint p1, MyPoint p2, MyPoint p)
        {
            return Math.Abs((p.Y - p1.Y) * (p2.X - p1.X) - (p2.Y - p1.Y) * (p.X - p1.X));
        }

        /// <summary>
        /// Вспомогательная задача для реализации левого правого поворотов.
        /// </summary>
        /// <param name="A">Начало отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="B">Конец отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="C">Точка, для которой определяется положение относительно отрезка AB.</param>
        /// <returns>Направление исходного поворота, если 1, то поворолт правый, если -1, то левый, если 0, то точки лежат на одной прямой.</returns>
        private int Rotate(MyPoint A, MyPoint B, MyPoint C)
        {
            double rotate = (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
            if (rotate < 0)
                return - 1;
            if (rotate > 0)
                return 1;
            return 0;
        }

        /// <summary>
        /// Обмен элементов местами.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap(List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        /// <summary>
        /// Вывод минимальной выпуклой оболочки.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Минимально выпуклая оболочка:");
            for(int i =0; i<minCH.Count; ++i)
                Console.Write(Points[minCH[i]] + " ");
            Console.WriteLine();
        }
    }
}
