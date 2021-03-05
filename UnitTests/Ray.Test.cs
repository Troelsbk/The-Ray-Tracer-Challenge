using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class RayTests
    {
        [Fact]
        public void rayTest()
        {
            //Creating Rays
            Point origin = new Point(1, 2, 3);
            Vector direction = new Vector(4, 5, 6);
            Ray r = new Ray(origin, direction);
            Assert.True(r.Origin == origin);
            Assert.True(r.Direction == direction);
            Ray r2 = new Ray(new Point(2, 3, 4), new Vector(1, 0, 0));
            Assert.True(r2.Position(0) == new Point(2, 3, 4));
            Assert.True(r2.Position(1) == new Point(3, 3, 4));
            Assert.True(r2.Position(-1) == new Point(1, 3, 4));
            Assert.True(r2.Position(2.5d) == new Point(4.5d, 3, 4));
            //Interscecting Rays with spheres



        }
    }
}
