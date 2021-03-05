using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Color
    {
        float red;
        float green;
        float blue;
        public Color()
        {
            red = 0;
            green = 0;
            blue = 0;
        }
        public Color(float red, float green, float blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public float Red
        {
            get { return red; }
        }
        public float Green
        {
            get { return green; }
        }
        public float Blue
        {
            get { return blue; }
        }
        static bool Equal(double inp_a, double inp_b)
        {
            double Epsilon = 0.00001;
            if(Math.Abs(inp_a - inp_b) < Epsilon)
            {
                return true; 
            }
            else { return false; }
        }
        public static Color operator +(Color input_a, Color input_b)
        {
            return new Color(       input_a.Red + input_b.Red,
                                    input_a.Green + input_b.Green,
                                    input_a.Blue + input_b.Blue );
        }
        public static bool operator ==(Color input_a, Color input_b)
        {
            bool temp_red = Equal((double)input_a.Red, (double)input_b.Red);
            bool temp_green = Equal((double)input_a.Green, (double)input_b.Green);
            bool temp_blue = Equal((double)input_a.Blue, (double)input_b.Blue);
            if(temp_red && temp_blue && temp_green) { return true;}
            else { return false; }
        }
        public static bool operator !=(Color input_a, Color input_b)
        {
            return !(input_a == input_b);
        }
        public static Color operator -(Color input_a, Color input_b)
        {
            return new Color(
                                    input_a.Red - input_b.Red,
                                    input_a.Green - input_b.Green,
                                    input_a.Blue - input_b.Blue
                                    );
        }
        public static Color operator *(Color input_color, float scalar) 
        {
            return new Color(       input_color.Red * scalar,
                                    input_color.Green * scalar,
                                    input_color.Blue * scalar );
        }
        public static Color operator *(Color input_a, Color input_b)
        {
            return new Color(       input_a.Red * input_b.Red,
                                    input_a.Green * input_b.Green,
                                    input_a.Blue * input_b.Blue );
        }
        public Color SetRed()
        {
            // TODO set class variables like matrix getRox (with all set methods).
            red = 255; green = 0; blue = 0;
            return this;
        }
        public static Color GetRed()
        {
            Color temp = new Color();
            temp.red = 255; 
            temp.green = 0; 
            temp.blue = 0;
            return temp;
        }
        public Color SetGreen()
        {
            red = 0; green = 255; blue = 0;
            return this;
        }
        public static Color GetGreen()
        {
            Color temp = new Color();
            temp.red = 0; 
            temp.green = 255; 
            temp.blue = 0;
            return temp;
        }
        public Color SetBlue()
        {
            red = 0; green = 0; blue = 255;
            return this;
        }
        public static Color GetBlue()
        {
            Color temp = new Color();
            temp.red = 0; 
            temp.green = 0; 
            temp.blue = 255;
            return temp;
        }
        public override string ToString()
        {
            return $"{red} {green} {blue}";
        }

    }
}
