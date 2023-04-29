﻿using ComputationalGeometry;
using System;
using System.Collections.Generic;

namespace CGTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> list = new List<Point>
            {
                new Point(1,1),
                new Point(6,1),
                new Point(4,2),
                new Point(9,2),
                new Point(3,4),
                new Point(8,4),
                new Point(5,5),
                new Point(10,5),
                new Point(2,6),
                new Point(6,7)
            };
            MCH mCH = new MCH(list);
            mCH.Graham();
            mCH.Print();
        }
    }
}
