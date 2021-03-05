using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Vector : Tuple
    {
        public Vector(double x, double y, double z) : base(x, y, z, 0)
        {
        }
        public Vector() : base(0d, 0d, 0d, 0d)
        {
        }
        public static bool operator ==(Vector inp_a, Vector inp_b)
        {
            bool x = Tuple.Equal(inp_a.x, inp_b.x);
            bool y = Tuple.Equal(inp_a.y, inp_b.y);
            bool z = Tuple.Equal(inp_a.z, inp_b.z);
            bool w = Tuple.Equal(inp_a.w, inp_b.w);
            if(x && y && z && w) { return true; }
            else { return false; }
        }
        public static bool operator !=(Vector inp_a, Vector inp_b)
        {
            return !(inp_a == inp_b);
        }
        public static Vector operator +(Vector inp_a, Vector inp_b)
        {
            //bool DoublePointTest = !(inp_a.w == 1 && inp_b.w == 1);
            //System.Diagnostics.Debug.Assert(DoublePointTest, "Unable to Add two Points!");
            double temp_x = inp_a.x + inp_b.x;
            double temp_y = inp_a.y + inp_b.y;
            double temp_z = inp_a.z + inp_b.z;
            return new Vector(temp_x, temp_y, temp_z);
        }
        public static Vector operator -(Vector inp_a, Vector inp_b)
        {
            //bool DoublePointTest = !(inp_a.w == 1 && inp_b.w == 1);
            //System.Diagnostics.Debug.Assert(DoublePointTest, "Unable to Add two Points!");
            double temp_x = inp_a.x - inp_b.x;
            double temp_y = inp_a.y - inp_b.y;
            double temp_z = inp_a.z - inp_b.z;
            return new Vector(temp_x, temp_y, temp_z);
        }
        public static Vector operator *(Vector input_vector, double scalar)
        {
            Vector temp = new Vector();
            temp.x = input_vector.x * scalar;
            temp.y = input_vector.y * scalar;
            temp.z = input_vector.z * scalar;
            return temp;
        }
        public Vector Negate()
        {
            this.x *= -1;
            this.y *= -1;
            this.z *= -1;
            this.w *= -1;
            return this;
        }
        public Vector Scale(double scalar)
        {
            x *= scalar;
            y *= scalar;
            z *= scalar;
            return this;
        }
        public double Magnitude()
        {
            double magnitude =  Math.Sqrt(  Math.Pow(x, 2) +
                                            Math.Pow(y, 2) +
                                            Math.Pow(z, 2));
            return magnitude;
        } 
        public Vector Normalize(float multiplier)
        {
            //method added to test canan on page 23;
            double magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
            w /= magnitude;
            x *= (double)multiplier;
            y *= (double)multiplier;
            z *= (double)multiplier;
            w *= (double)multiplier;
            return this;

        }
        public Vector Normalize()
        {
            double magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
            w /= magnitude;
            return this;
        }
        public double Dot(Vector input_vector)
        {
            return  x * input_vector.x +
                    y * input_vector.y +
                    z * input_vector.z;
        }
        public Vector Cross(Vector b)
        {
            double temp_x = y * b.z - z * b.y;
            double temp_y = z * b.x - x * b.z;
            double temp_z = x * b.y - y * b.x;
            x = temp_x;
            y = temp_y;
            z = temp_z;
            return this;
        }
    }
}
