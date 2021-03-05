using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Point : Tuple
    {
        public Point(double x, double y, double z) : base(x, y, z, 1)
        {
        }
        public Point() :base(0d, 0d, 0d, 1d)
        {
        }

        public static bool operator ==(Point inp_a, Point inp_b)
        {
            bool x = Tuple.Equal(inp_a.x, inp_b.x);
            bool y = Tuple.Equal(inp_a.y, inp_b.y);
            bool z = Tuple.Equal(inp_a.z, inp_b.z);
            bool w = Tuple.Equal(inp_a.w, inp_b.w);
            if(x && y && z && w) { return true; }
            else { return false; }
        }
        public static bool operator !=(Point inp_a, Point inp_b)
        {
            return !(inp_a == inp_b);
        }
        public static Point operator +(Point inp_a, Vector inp_b)
        {
            //bool DoublePointTest = !(inp_a.w == 1 && inp_b.w == 1);
            //System.Diagnostics.Debug.Assert(DoublePointTest, "Unable to Add two Points!");
            double temp_x = inp_a.x + inp_b.x;
            double temp_y = inp_a.y + inp_b.y;
            double temp_z = inp_a.z + inp_b.z;
            return new Point(temp_x, temp_y, temp_z);
        }
        public static Point operator +(Vector inp_a, Point inp_b)
        {
            double temp_x = inp_a.x + inp_b.x;
            double temp_y = inp_a.y + inp_b.y;
            double temp_z = inp_a.z + inp_b.z;
            return new Point(temp_x, temp_y, temp_z);
        }
        public static Vector operator -(Point inp_a, Point inp_b)
        {
            //Subtracting two point gives a vector
            double temp_x = inp_a.x - inp_b.x;
            double temp_y = inp_a.y - inp_b.y;
            double temp_z = inp_a.z - inp_b.z;
            return new Vector(temp_x, temp_y, temp_z);
        }
        public static Point operator -(Point inp_a, Vector inp_b)
        {
            double temp_x = inp_a.x - inp_b.x;
            double temp_y = inp_a.y - inp_b.y;
            double temp_z = inp_a.z - inp_b.z;
            return new Point(temp_x, temp_y, temp_z);
        }
        public Point Negate()
        {
            this.x *= -1;
            this.y *= -1;
            this.z *= -1;
            //this.w *= -1;
            return this;
        }
        public Point Scale(double scalar)
        {
            this.x *= scalar;
            this.y *= scalar;
            this.z *= scalar;
            //this.w *= scalar;
            return this;
        }
    }
}
