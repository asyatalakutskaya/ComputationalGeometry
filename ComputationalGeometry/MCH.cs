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
    public class Point
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
        public Point()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса Point.
        /// </summary>
        /// <param name="x">Координата по оси OX.</param>
        /// <param name="y">Координата по оси OY.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }

    /// <summary>
    /// Класс, реализующий алгоритмы построения минимально выпуклых оболочек.
    /// </summary>
    public class MCH
    {
        /// <summary>
        /// Количество точек в множестве.
        /// </summary>
        int N;
        /// <summary>
        /// Множество точек.
        /// </summary>
        List<Point> Points;

        public MCH()
        {
            Points = new List<Point>();
            N = 0;
        }
        public MCH(List<Point> p)
        {
            Points = p;
            N = Points.Count;
        }

        //НЕ РАБОТАЕТ ИЗ-ЗА СОРТИРОВКИ ТОЧЕК!!!
        public List<int> Graham()
        {
            List<int> P = new List<int>();//список номеров точек
            for (int i = 0; i < N; ++i)
                P.Add(i);
            //Выбор стартовой точки(самая левая) и перестановка её нгомера в начало
            for (int i = 1; i < N; ++i)
                if (Points[P[i]].X < Points[P[0]].X) //если P[i]-ая точка лежит левее P[0]-ой точки
                    Swap(P, P[i], P[0]); //меняем местами номера этих точек 
            for (int i = 2; i < N; ++i) //сортировка вставкой //НЕПРАВИЛЬНО!!!
            { 
                int j = i;
                while (j > 1 && (Rotate(Points[P[0]], Points[P[j - 1]], Points[P[j]]) < 0))
                {
                    Swap(P, P[j], P[j - 1]);
                    j -= 1;
                }
            }
            for (int i = 0; i < N; ++i)
                Console.WriteLine(P[i]);
            List<int> S = new List<int>() { P[0], P[1] };//создаем стек
            for (int i = 2; i < N; ++i)
            {
                while (Rotate(Points[S[S.Count-2]], Points[S[S.Count - 1]], Points[P[i]]) < 0)
                    S.RemoveAt(S.Count-1); //pop(S)
                
                S.Add(P[i]); //push(S,P[i])
            }
            return S;
        }

        public List<int> Jarvismarch()
        {
            List<int> P = new List<int>();//список номеров точек
            for (int i = 0; i < N; ++i)
                P.Add(i);
            for (int i = 1; i < N; ++i)
                if (Points[P[i]].X < Points[P[0]].X)
                    Swap(P, P[i], P[0]);  //swap
            List<int> H = new List<int>() { P[0] };
            P.RemoveAt(0);//удаляем элеменнт из начала и сохраняем его в конце
            P.Add(H[0]);
            while (true)
            {
                int right = 0;
                for (int i = 1; i < P.Count; ++i)
                    if (Rotate(Points[H[H.Count - 1]], Points[P[right]], Points[P[i]]) < 0)
                        right = i;
                if (P[right] == H[0])
                    break;
                else
                {
                    H.Add(P[right]);
                    P.RemoveAt(right);
                }
            }
            return H;
        }

        public void printHull(List<List<int>> a)
        {
            // a[i].second -> y-coordinate of the ith point
            if (N < 3)
                return;

            // Finding the point with minimum and
            // maximum x-coordinate
            int min_x = 0;
            int max_x = 0;
            for (int i = 1; i < N; i++)
            {
                if (a[i][0] < a[min_x][0])
                {
                    min_x = i;
                }
                if (a[i][0] > a[max_x][0])
                {
                    max_x = i;
                }
            }

            // Recursively find convex hull points on
            // one side of line joining a[min_x] and
            // a[max_x]
            quickHull(a, a[min_x], a[max_x], 1);
            quickHull(a, a[min_x], a[max_x], -1);

            Console.Write("The points in Convex Hull are:\n");
            foreach (var item in hull)
            {
                Console.WriteLine(item[0] + " " + item[1]);
            }
        }

        public void quickHull(List<List<int>> a,
                                 List<int> p1, List<int> p2,
                                 int side)
        {
            int ind = -1;
            int max_dist = 0;

            // finding the point with maximum distance
            // from L and also on the specified side of L.
            for (int i = 0; i < N; i++)
            {
                int temp = Rotate(p1, p2, a[i]);
                if (findSide(p1, p2, a[i]) == side
                    && temp > max_dist)
                {
                    ind = i;
                    max_dist = temp;
                }
            }

            // If no point is found, add the end points
            // of L to the convex hull.
            if (ind == -1)
            {
                hull.Add(p1);
                hull.Add(p2);
                return;
            }

            // Recur for the two parts divided by a[ind]
            quickHull(a, a[ind], p1,
                      -findSide(a[ind], p1, p2));
            quickHull(a, a[ind], p2,
                      -findSide(a[ind], p2, p1));
        }

        // Returns the side of point p with respect to line
        // joining points p1 and p2.
        public static int findSide(List<int> p1, List<int> p2, List<int> p)
        {
            int val = (p[1] - p1[1]) * (p2[0] - p1[0])
                      - (p2[1] - p1[1]) * (p[0] - p1[0]);

            if (val > 0)
            {
                return 1;
            }
            if (val < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Вспомогательная задача для реализации левого правого поворотов.
        /// </summary>
        /// <param name="A">Начало отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="B">Конец отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="C">Точка, для которой определяется положение относительно отрезка AB.</param>
        /// <returns>Направление исходного поворота, если 1, то поворолт правый, если -1, то левый, если 0, то точки лежат на одной прямой.</returns>
        private double Rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
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
    }
}
