using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Ray
    {
        Point origin;
        Vector direction;
        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
        public Point Origin
        {
            get { return origin;}
        }
        public Vector Direction
        {
            get { return direction;}
        }
        public Point Position(double t)
        {
            Point temp = origin + (direction * t);
            return temp;
        }
        public override string ToString()
        {
            return $"{origin}, {direction}";
        }


    }
}
