using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Canvas
    {
        private readonly int height;
        private readonly int width;
        Color[,] canvas;
        public int ColorDepth = 255;
        public Canvas(int width, int height)
        {
            this.height = height;
            this.width = width;
            canvas = new Color[height, width];
            InitializeCanvas();
        }
        void InitializeCanvas()
        {
            Color defaultColor = new Color(0, 0, 0);
            for (int r = 0; r < GetHeight; r++)
            {
                for (int c = 0; c < GetWidth; c++)
                {
                    canvas[r, c] = defaultColor;
                }
            }
        }
        public int GetWidth
        {
            get { return width; }
        }
        public int GetHeight
        {
            get { return height; }
        }
        public Color GetPixel(int x, int y)
        {
            return canvas[x, y];
        }
        public void SetPixel(int width, int height, Color color)
        {
            WritePixel(width, height, color);
        }
        private void WritePixel(int x, int y, Color Color)
        {
            //Use the method to correct reverse y coordinate.
            //This method was intruduced with SetPixel(...., double scalar) 
            //so that there where only one private write method(not realy needed)
            bool error = true;
            if(x >= height || y >= width) { error = false; }
            System.Diagnostics.Debug.Assert(error, $"({x},{y}) Coordinate outside of canvas!");
            //canvas[x, height - 1- y] = Color;
            canvas[x, y] = Color;
        }
        public void SetPixel(Point Point, Color Color, double scalar)
        {
            //method implemented to be used with canon
            int x = (int)(Point.x * scalar);
            int y = (int)(Point.y * scalar);
            WritePixel(x, y, Color);
        }
        public void SetPixel(Point position, Color Color)
        {
            WritePixel((int)position.x, (int)position.y, Color);
        }
        public override string ToString()
        {
            string return_string = ""; 
            for (int r = 0; r < GetHeight; r++)
            {
                for (int c = 0; c < GetWidth; c++)
                {
                    return_string += canvas[r, c].ToString() + " ";
                }
                return_string.Trim();
                return_string += "\n";
            }
            return_string += "\n";
            return return_string;

        }
        static private int NormalizeColor(int MaxColorValue, float ColorValue)
        //Calculate color value with respector to Maximum color value on canvas
        {
            float value = ColorValue * MaxColorValue;
            if (value > 255)
            { value = 255; }
            if (value < 0) { value = 0; }
            return (int)value;
        }
        public string GetPPMHeader()
        {
            return $"P3\n{GetWidth} " + $"{GetHeight}\n{ColorDepth}\n";
        }
        public void Print()
        {
            // TODO implement filename arguement
            //string FilePath = @"C:\Users\troels\Source\Repos\Files\CanvasTestWritings";
            string FilePath = @"C:\Users\troels\Source\Repos\Files\canvas.txt";
            Console.WriteLine($"Wrote to {FilePath}.");
            string image_data = "";
            FileStream fd = new FileStream(FilePath, FileMode.Truncate, FileAccess.Write);
            fd.Flush();
            //fd.Write(Encoding.UTF8.GetBytes(GetPPMHeader()));
            fd.Write(Encoding.UTF8.GetBytes(GetPPMHeader()));
            //for (int _height = 0; _height < GetHeight; _height++)
            for (int  _width = 0;  _width < GetHeight; _width ++)
            {
                for (int _height = 0; _height < GetWidth; _height++)
                {
                    Color Pixel = GetPixel(_width, _height); //original
                    int PixelRedVal = NormalizeColor(ColorDepth, Pixel.Red);
                    int PixelGreenVal = NormalizeColor(ColorDepth, Pixel.Green);
                    int PixelBlueVal = NormalizeColor(ColorDepth, Pixel.Blue);
                    string stringColorCode = $" {PixelRedVal} {PixelGreenVal} {PixelBlueVal}";
                    image_data += stringColorCode;
                    //if (image_data.Length % 60 == 0) {
                    //    Console.WriteLine("added new line");
                    //    image_data += $"\n"; }
                    byte[] binaryImage = Encoding.UTF8.GetBytes(image_data);
                    fd.Write(binaryImage);
                    image_data = "";
                }
            }
            fd.WriteByte(0x0A); //Add newline to end of PPM file.
            fd.Close();
        }

    }
}
