using System;
using RTC;
using Xunit;

namespace RTC
{
    public class TupleTests
    {
        [Fact]
        public void tupleTests()
        {
            //
            //
            //CHAPTOR ONE
            //
            //
            Tuple a = new Tuple(4.3d, -4.2d, 3.1d, 1.0);
            Assert.True(a.x == 4.3d);
            Assert.True(a.y == -4.2d);
            Assert.True(a.z == 3.1d);
            Assert.True(a.w == 1.0d);
            Assert.True(a.IsPoint());
            Assert.False(a.IsVector());

            Tuple b = new Tuple(4.3d, -4.2d, 3.1d, 0.0);
            Assert.True(b.x == 4.3d);
            Assert.True(b.y == -4.2d);
            Assert.True(b.z == 3.1d);
            Assert.True(b.w == 0.0d);
            Assert.False(b.IsPoint());
            Assert.True(b.IsVector());

            Point p = new Point(4, -4, 3);
            Point p2 = new Point(4, -4, 3);
            Point p3 = new Point(4, -4, 3.1d);
            Assert.True(p == p2);
            Assert.True(p != p3);
            Assert.False(p != p2);
            Assert.False(p == p3);

            Vector v = new Vector(4, -4, 3);
            Vector v2 = new Vector(4, -4, 3);
            Vector v3 = new Vector(4, -4, 3.1d);
            Assert.True(v == v2);
            Assert.True(v != v3);
            Assert.False(v != v2);
            Assert.False(v == v3);

            //ADDING OPERATIONS 
            //NOT POSSIBLE TO ADD TWO POINTS
            Vector v4 = new Vector(3, -2, 5); 
            Vector v5 = new Vector(-2, 3, 1);
            Point add_point1 = new Point(1, 2, 3);
            Assert.True(new Point(-1, 5, 4) == add_point1 + v5);
            Assert.True(new Vector(1, 1, 6) == v4 + v5);
            Assert.False(new Vector(2, 1, 6) == v4 + v5);

            //SUBTRACTION OPERATIONS
            //Point - Point
            Point point_sub = new Point(3, 2, 1);
            Point point_sub2 = new Point(5, 6, 7);
            Vector sub_points_exp = new Vector(-2, -4, -6);
            Assert.True(sub_points_exp == (point_sub - point_sub2));
            //Point - Vector
            Point p4 = new Point(3, 2, 1);
            Vector v6 = new Vector(5, 6, 7);
            Point point_result = p4 - v6;
            Point expected_sub_result = new Point(-2, -4, -6);
            Assert.True(point_result == expected_sub_result);
            //vector-vector
            Vector sub_vector = new Vector(3, 2, 1);
            Vector sub_vector_2 = new Vector(5, 6, 7);
            Vector sub_result = new Vector(-2, -4, -6);
            Assert.True(sub_result == sub_vector - sub_vector_2);
            //NEGATE
            Vector neg_vector = new Vector(1, -2, 3);
            Vector neg_vector_result = new Vector(-1, 2, -3);
            Assert.True(neg_vector_result == neg_vector.Negate());
            Point neg_point = new Point(1, -2, 3);
            Point neg_point_result = new Point(-1, 2, -3);
            Assert.True(neg_point_result == neg_point.Negate());
            //SCALAR
            Vector scalar_v1 = new Vector(1, -2, 3);
            Vector scaled_vector = new Vector(3.5d, -7, 10.5d);
            Assert.True(scaled_vector == scalar_v1.Scale(3.5d));
            Vector scaled_by_fraction = new Vector(0.5d, -1, 1.5d);
            Vector scalar_v2 = new Vector(1, -2, 3);
            Assert.True(scaled_by_fraction == scalar_v2.Scale(0.5d));
            //MAGNITUDE
            Vector magni_vector_1 = new Vector(1, 0, 0);
            Vector magni_vector_2 = new Vector(0, 1, 0);
            Vector magni_vector_3 = new Vector(0, 0, 1);
            Vector magni_vector_4 = new Vector(1, 2, 3);
            Vector magni_vector_5 = new Vector(-1, -2, -3);
            Assert.Equal(1, magni_vector_1.Magnitude());
            Assert.Equal(1, magni_vector_2.Magnitude());
            Assert.Equal(1, magni_vector_3.Magnitude());
            Assert.Equal(Math.Sqrt(14), magni_vector_4.Magnitude());
            Assert.Equal(Math.Sqrt(14), magni_vector_5.Magnitude());
            //NORMALIZATION
            Vector norm_vector_1 = new Vector(4, 0, 0);
            Assert.True(new Vector(1, 0, 0) == norm_vector_1.Normalize());
            Vector norm_vector_2 = new Vector(1, 2, 3);
            Vector norm_ref_vector = new Vector(1/Math.Sqrt(14), 2/Math.Sqrt(14), 3/Math.Sqrt(14));
            Assert.True(norm_ref_vector == norm_vector_2.Normalize());
            Vector norm_vector_3 = new Vector(1, 2, 3);
            Assert.Equal(1, norm_vector_3.Normalize().Magnitude());
            //DOT PRODUCT
            Vector dot_vector_1 = new Vector(1, 2, 3);
            Vector dot_vector_2 = new Vector(2, 3, 4);
            Assert.Equal(20, dot_vector_1.Dot(dot_vector_2));
            //CROSS PRODUCT
            Vector cross_vector_1 = new Vector(1, 2, 3);
            Vector cross_vector_2 = new Vector(2, 3, 4);
            Vector cross_1_2_result = new Vector(-1, 2, -1);
            Vector cross_2_1_result = new Vector(1, -2, 1);
            cross_vector_1.Cross(cross_vector_2);
            Assert.True(cross_1_2_result == cross_vector_1);
            Vector cross_vector_3 = new Vector(1, 2, 3);
            Assert.True(cross_2_1_result == cross_vector_2.Cross(cross_vector_3));


        }
    }
}
