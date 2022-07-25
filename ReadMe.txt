========Lights Out=======

- Run the project as normal
- Default grid size is 5x5, but you can specify any size apart from 0. Specify a size and click generate

I used Windows Forms for this project as it was the most straight forward. Also I hadn't use it for ages and thought it would be fun.

The project comprises of a single form, and a custom user control which generates the light grid.

LightsController is the main class that deals with interaction. Each light is an instance of the light class.

LightsController generates a 2D array of a specified size and then listens for Light click events.

Tests cover common scenarios as well as edge cases such as zero length grids.

Improvements:
- Add a score
- End the game when lights are out
- Adjustable light sizes (currently 50px)