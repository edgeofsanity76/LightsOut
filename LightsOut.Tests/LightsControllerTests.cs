using NUnit.Framework;
using System;

namespace LightsOut.Tests
{
    public class LightsControllerTests
    {
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,3)]
        [TestCase(4,4)]
        [TestCase(5,5)]
        [TestCase(4,7)]
        public void ShouldGenerateLightArrayOfSpecifiedSizeAndNoLightsShouldBeOn(int sizeX, int sizeY)
        {
            var lightsController = new LightsController<System.Windows.Forms.Button>();

            var lightArray = lightsController.GenerateLightArray(sizeX, sizeY, false);

            var sizeXMax = lightArray.GetLength(0);
            var sizeYMax = lightArray.GetLength(1);

            Assert.AreEqual(sizeX, sizeXMax);
            Assert.AreEqual(sizeY, sizeYMax);
        }

        [TestCase(5, 5)]
        [TestCase(3, 3)]
        [TestCase(1, 1)]
        public void ShouldGenerateLightArrayAndSomeLightsShouldBeOn(int sizeX, int sizeY)
        {
            var lightsController = new LightsController<System.Windows.Forms.Button>();

            var lightArray = lightsController.GenerateLightArray(sizeX, sizeY, true);

            for (var x = 0; x < lightArray.GetLength(0); x++)
            {
                for (var y = 0; y < lightArray.GetLength(1); y++)
                {
                    if (lightArray[x,y].IsOn)
                        Assert.Pass();
                }
            }

            Assert.Fail("No lights were on in the array");
        }

        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        public void ShouldThrowExceptionIfDimensionSizeIsZeroOrLess(int sizeX, int sizeY)
        {
            var lightsController = new LightsController<System.Windows.Forms.Button>();
            Assert.Throws<Exception>(() => lightsController.GenerateLightArray(sizeX, sizeY, true));
        }
    }
}