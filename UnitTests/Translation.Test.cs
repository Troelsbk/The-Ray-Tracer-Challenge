using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class Transforming
    {
        [Fact]
        public void transforming()
        {
            //TRANSLATION
            Matrix translate = new Matrix().Translation(5, -3, 2);
            Point p = new Point(-3, 4, 5);
            Assert.True(translate * p == new Point(2, 1, 7));
            Matrix inv = Matrix.Inverse(translate);
            Assert.True(inv * p == new Point(-8, 7, 3));
            Vector v = new Vector(-3, 4, 5);
            Assert.True(translate * v == v);
            //SCALING
            Matrix scale = new Matrix().Scaling(2, 3, 4);
            Point p2 = new Point(-4, 6, 8);
            Assert.True(scale * p2 == new Point(-8, 18, 32));

            Vector v2 = new Vector(-4, 6, 8);
            Assert.True(scale * v2 == new Vector(-8, 18, 32));

            Matrix scale_inv = Matrix.Inverse(scale);
            Vector v3 = new Vector(-4, 6, 8);
            Assert.True(scale_inv * v3 == new Vector(-2, 2, 2));

            Matrix scale_2 = new Matrix().Scaling(-1, 1, 1);
            Point p3 = new Point(2, 3, 4);
            Assert.True(scale_2 * p3 == new Point(-2, 3, 4));

            //ROTATION AROUND X
            double PI = Math.PI;
            double sq2 = Math.Sqrt(2);
            Point p4 = new Point(0, 1, 0);
            Matrix half_quarter = new Matrix().Rotate_x(PI / 4);
            Matrix full_quarter = new Matrix().Rotate_x(PI / 2);
            Assert.True(half_quarter * p4 == new Point(0, sq2 / 2, sq2 / 2));
            Assert.True(full_quarter * p4 == new Point(0, 0, 1));
            Point p5 = new Point(0, 1, 0);
            Matrix inv_half_quarter = half_quarter.Transpose();
            Assert.True(inv_half_quarter * p5 == new Point(0, sq2 / 2, -sq2 / 2));

            //ROTATION AROUND Y
            Point p6 = new Point(0, 0, 1);
            Matrix half_quarter_y = new Matrix().Rotate_y(PI / 4);
            Matrix full_quarter_y = new Matrix().Rotate_y(PI / 2);
            Point result_y = half_quarter_y * p6;
            Assert.True( result_y == new Point(sq2/2, 0, sq2/2));
            Assert.True(full_quarter_y * p6 == new Point(1, 0, 0));

            //ROTATION AROUND Z
            Point p7 = new Point(0, 1, 0);
            Matrix half_quarter_z = new Matrix().Rotate_z(PI / 4);
            Matrix full_quarter_z = new Matrix().Rotate_z(PI / 2);
            Point temp = half_quarter_z * p7;
            Assert.True(temp == new Point(-1 * sq2 / 2, sq2 / 2, 0));
            Assert.True(full_quarter_z * p7 == new Point(-1, 0, 0));

            //SHEARING
            Point shearPoint = new Point(2, 3, 4);
            Matrix s1 = new Matrix().Shearing(0, 1, 0, 0, 0, 0);
            Assert.True(s1 * shearPoint == new Point(6, 3, 4));
            Matrix s2 = new Matrix().Shearing(0, 0, 1, 0, 0, 0);
            Assert.True(s2 * shearPoint == new Point(2, 5, 4));
            Matrix s3 = new Matrix().Shearing(0, 0, 0, 1, 0, 0);
            Assert.True(s3 * shearPoint == new Point(2, 7, 4));
            Matrix s4 = new Matrix().Shearing(0, 0, 0, 0, 1, 0);
            Assert.True(s4 * shearPoint == new Point(2, 3, 6));
            Matrix s5 = new Matrix().Shearing(0, 0, 0, 0, 0, 1);
            Assert.True(s5 * shearPoint == new Point(2, 3, 7));

        }
        [Fact]
        public void chaining()
        {
            double PI = Math.PI;
            //CHAINING TRANSFORMATIONS
            Point p = new Point(1, 0, 1);
            Matrix A = new Matrix().Rotate_x(PI / 2);
            Matrix B = new Matrix().Scaling(5, 5, 5);
            Matrix C = new Matrix().Translation(10, 5, 7);
            //Apply rotation 
            Point p2 = A * p;
            Assert.True(p2 == new Point(1, -1, 0));
            //Apply scaling
            Point p3 = B * p2;
            Assert.True(p3 == new Point(5, -5, 0));
            //Apply translation
            Point p4 = C * p3;
            Assert.True(p4 == new Point(15, 0, 7));
            //Showing reverse order
            Point p5 = new Point(1, 0, 1);
            Matrix A2 = new Matrix().Rotate_x(PI / 2);
            Matrix B2 = new Matrix().Scaling(5, 5, 5);
            Matrix C2 = new Matrix().Translation(10, 5, 7);
            Matrix T = C2 * B2 * A2;
            Assert.True(T * p5 == new Point(15, 0, 7));
        }
    }
}
