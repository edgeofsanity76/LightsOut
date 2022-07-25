using System;

namespace LightsOut
{
    /// <summary>
    /// The light controller. Is responsible for generating a 2 dimensional array of lights and listening for click events
    /// </summary>
    /// <typeparam name="TControl">Any windows form control should work as a 'light'</typeparam>
    public class LightsController<TControl> where TControl : System.Windows.Forms.Control
    {
        private Light<TControl>[,] _lightsArray;

        /// <summary>
        /// Generates the 2d light array with a specified size and optionally will randomly switch on some lights. It will register a handler with each of the lights click events. See Light.cs class.
        /// </summary>
        /// <param name="sizeX">The width of the grid</param>
        /// <param name="sizeY">The height of the grid</param>
        /// <param name="applyRandomLights">Randomly turn on some lights</param>
        /// <returns></returns>
        public Light<TControl>[,] GenerateLightArray(int sizeX, int sizeY, bool applyRandomLights)
        {
            if (sizeX <= 0 || sizeY <= 0)
                throw new Exception("Light array cannot be zero in any dimension");

            var randomLightApplied = false;
            var random = new Random(DateTime.Now.Millisecond);
            _lightsArray = new Light<TControl>[sizeX, sizeY];

            for (var x = 0; x < sizeX; x++)
            {
                for (var y = 0; y < sizeY; y++)
                {
                    _lightsArray[x, y] = new Light<TControl>(x, y);

                    var randomNumber = random.Next();

                    if (applyRandomLights && randomNumber % 2 == 0)
                    {
                        _lightsArray[x, y].Toggle();
                        randomLightApplied = true;
                    }

                    _lightsArray[x, y].IsClicked += LightsGenerator_IsClicked;
                }
            }

            //Ensure at least one light is on
            if (!randomLightApplied && applyRandomLights)
                _lightsArray[0,0].Toggle();

            return _lightsArray;
        }

        private void LightsGenerator_IsClicked(int posX, int posY)
        {
            ToggleAdjacentLights(posX, posY);
        }

        /// <summary>
        /// Give a lights position in the array, toggle the adjacent lights
        /// </summary>
        /// <param name="posX">The X position of the light</param>
        /// <param name="posY">The Y position of the light</param>
        public void ToggleAdjacentLights(int posX, int posY)
        {
            var xMax = _lightsArray.GetLength(0) - 1;
            var yMax = _lightsArray.GetLength(1) - 1;

            if (xMax <= 0 || yMax <= 0) return;

            if ((posX -1) >= 0 && posX <= xMax)
                _lightsArray[posX - 1, posY].Toggle();

            if ((posX  + 1) >= 0 && (posX + 1) <= xMax && posX <= xMax)
                _lightsArray[posX + 1, posY].Toggle();

            if ((posY - 1) >= 0 && posY <= yMax)
                _lightsArray[posX, posY - 1].Toggle();

            if ((posY + 1) >= 0 && (posY + 1) <= yMax && posY <= yMax)
                _lightsArray[posX, posY + 1].Toggle();
        }
    }
}
