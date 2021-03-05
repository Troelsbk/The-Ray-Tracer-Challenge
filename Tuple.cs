using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Tuple
    {
        public double x;
        public double y;
        public double z;
        public double w;

        public Tuple()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.w = 0; 
        }
        public Tuple(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w; 
        }
        public bool IsPoint()
        {
            return Convert.ToBoolean(w);
        }
        public bool IsVector()
        {
            return !IsPoint();
        }
        public override string ToString()
        {
            return $"{this.x} {this.y} {this.z}";
        }
        public static bool Equal(double inp_a, double inp_b)
        {
            double Epsilon = 0.00001;
            if(Math.Abs(inp_a - inp_b) < Epsilon)
            {
                return true; 
            }
            else { return false; }
        }
        public bool IsEqual(Tuple inp_b)
        {
            if (Equal(this.x, inp_b.x) &&
                Equal(this.y, inp_b.y) &&
                Equal(this.z, inp_b.z) &&
                Equal(this.w, inp_b.w) )
            {
                return true;
            }
            return false;
        }
    }
}
