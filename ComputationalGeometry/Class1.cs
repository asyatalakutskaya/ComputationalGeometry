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
        public void Graham()
        {

        }
        /// <summary>
        /// Вспомогательная задача для реализации левого правого поворотов.
        /// </summary>
        /// <param name="A">Начало отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="B">Конец отрезка, относительно которого будем определять положение точки.</param>
        /// <param name="C">Точка, для которой определяется положение относительно отрезка AB.</param>
        /// <returns>Направление исходного поворота, если 1, то поворолт правый, если -1, то левый, если 0, то точки лежат на одной прямой.</returns>
        public int Rotate(Point A, Point B, Point C)
        {
            double rotation = (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
            if (rotation > 0)
                return 1;
            if (rotation < 0)
                return -1;
            return 0;
        }
    }
}
