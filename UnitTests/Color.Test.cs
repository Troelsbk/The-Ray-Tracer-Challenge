using Xunit;
using System;
using RTC;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class ColorTests
    {
        [Fact]
        public void colorTests()
        {
            Color c = new Color(-0.5f, 0.4f, 1.7f);
            Assert.Equal(-0.5f, c.Red);
            Assert.Equal(0.4f, c.Green);
            Assert.Equal(1.7f, c.Blue);
            Color c2 = new Color(0.9f, 0.6f, 0.75f);
            Color c3 = new Color(0.7f, 0.1f, 0.25f);
            Color added_c2_c3 = c2 + c3;
            Color c4_expected = new Color(1.6f, 0.7f, 1.0f);
            Assert.True(c4_expected == added_c2_c3);
            Assert.True(c4_expected != c2);
            Assert.False(c4_expected == c2);
            Assert.False(c4_expected != c4_expected);//compare to same variable? YES
            Color c6_sub_expected = new Color(0.2f, 0.5f, 0.5f);
            Assert.True(c6_sub_expected == c2 - c3);
            Color c7 = new Color(0.2f, 0.3f, 0.4f);
            Color c7_scaled = new Color(0.4f, 0.6f, 0.8f);
            Assert.True(c7_scaled == c7 * 2);
            Color c8 = new Color(1, 0.2f, 0.4f);
            Color c9 = new Color(0.9f, 1, 0.1f);
            Assert.True(new Color(0.9f, 0.2f, 0.04f) == c8 * c9);
        }
    }
}
