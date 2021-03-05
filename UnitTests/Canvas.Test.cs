using System;
using Xunit;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class CanvasTest
    {
        [Fact]
        public void canvasTest()
        {
            Canvas c = new Canvas(10, 20);
            Assert.Equal(10, c.GetWidth);
            Assert.Equal(20, c.GetHeight);
            Color red = new Color(1, 0, 0);
            c.SetPixel(2, 3, red);
            Assert.True(red == c.GetPixel(2, 3));
            //Saving Canvas
            Canvas c2 = new Canvas(5, 3);
            String ppm_header_ref = "\"\"\"\nP3\n5 3\n255\n\"\"\"";



        }
    }
}
