using ComputationalGeometry;
using System;
using System.Collections.Generic;

namespace CGTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyPoint> list = new List<MyPoint>
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
            MCH mCH = new MCH(list);
            mCH.printHull();
            mCH.Print();
        }
    }
}
