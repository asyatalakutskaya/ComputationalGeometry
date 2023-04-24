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
        
        public List<int> Graham()
        {
            int[] P = new int[N];//список номеров точек
            for(int i = 0; i<N; ++i)
            {
                P[i] = i;
            }
            for (int i = 0; i < N; ++i)
                if (Points[P[i]].X < Points[P[0]].X) //если P[i]-ая точка лежит левее P[0]-ой точки
                    Swap(P[i], P[0]); //меняем местами номера этих точек 
            for (int i = 2; i < N; ++i) //сортировка вставкой
            { 
                int j = i;
                while (j > 1 && (Rotate(Points[P[0]], Points[P[j - 1]], Points[P[j]]) < 0))//разобраться с возвратом Rotate
                {
                    Swap(P[j], P[j - 1]);
                    j -= 1;
                }
            }
            List<int> S = new List<int>();//создаем стек
            S.Add(P[0]);
            S.Add(P[1]);
            for (int i = 2; i < N; ++i)
            {
                while (Rotate(Points[S[-2]], Points[S[-1]], Points[P[i]]) < 0)
                    S.RemoveAt(S.Count-1); //pop(S)    //либо удалять с начала либо удалять с конца???????????????
                S.Add(P[i]); //push(S,P[i])
            }
            return S;
        }

        /// <summary>
        /// Вспомогательная задача для реализации левого правого поворотов.
        /// </summary>
        /// <param name="A">Начало отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="B">Конец отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="C">Точка, для которой определяется положение относительно отрезка AB.</param>
        /// <returns>Направление исходного поворота, если 1, то поворолт правый, если -1, то левый, если 0, то точки лежат на одной прямой.</returns>
        private int Rotate(Point A, Point B, Point C)
        {
            double rotation = (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
            if (rotation > 0)
                return 1;
            if (rotation < 0)
                return -1;
            return 0;
        }
    
        private void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
