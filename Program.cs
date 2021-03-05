using System.Timers;
using System.Collections.Generic;
using System;

namespace RTC
{
    class Program
    {
        static void Main(string[] args)
        {
            Ray r = new Ray(new Point(2, 3, 4), new Vector(1, 0, 0));
            Console.WriteLine(r);
            //Console.WriteLine(r.Position(0));
            Console.WriteLine(r.Position(1));
            Console.WriteLine($"ray {r}");
            Console.WriteLine(r.Position(-1));
            Console.WriteLine($"ray {r}");
            Console.WriteLine(r.Position(2.5d));
            Console.WriteLine($"ray {r}");
        }
    }
}
