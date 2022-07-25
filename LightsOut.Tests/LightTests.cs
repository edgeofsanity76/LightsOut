using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace LightsOut.Tests
{
    public class LightTests
    {
        [TestCase(1,2)]
        [TestCase(3,4)]
        public void ShouldConstructCorrectlyWithGivenXy(int x, int y)
        {
            var light = new Light<System.Windows.Forms.Button>(x ,y);

            Assert.AreEqual(light.LightControl.GetType(), typeof(System.Windows.Forms.Button));
            Assert.AreEqual(light.LightControl.Left, x * 50);
            Assert.AreEqual(light.LightControl.Top, y * 50);
            Assert.AreEqual(light.LightControl.BackColor, System.Drawing.Color.Gray);
            Assert.AreEqual(light.PosX, x);
            Assert.AreEqual(light.PosY, y);
        }

        [TestCase(-1, -2)]
        public void ShouldThrowExceptionIfPositionIsNegative(int x, int y)
        {
            Assert.Throws<Exception>(() => new Light<Button>(x, y));
        }
    }
}

