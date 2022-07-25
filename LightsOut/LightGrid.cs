using System;
using System.Windows.Forms;

namespace LightsOut
{
    /// <summary>
    /// Houses the light grid. Allows for parameters to be set (grid size) and for the user to generate the grid
    /// </summary>
    public partial class LightGrid : UserControl
    {
        public int GridX
        {
            get => (int)numX.Value;
            set
            {
                _gridX = value;
                _gridX = (int) numX.Value;
            }
        }

        public int GridY
        {
            get => (int)numY.Value;
            set
            {
                _gridX = value;
                _gridY = (int) numY.Value;
            }
        }

        private int _gridX = 5;
        private int _gridY = 5;

        public LightGrid()
        {
            InitializeComponent();
        }

        public void GenerateLightGrid()
        {
            pnlGrid.Controls.Clear();

            var generator = new LightsController<Button>();
            var lights = generator.GenerateLightArray(_gridX, _gridY, true);

            for (var x = 0; x < lights.GetLength(0); x++)
            {
                for (var y = 0; y < lights.GetLength(1); y++)
                {
                    var control = lights[x, y];
                    pnlGrid.Controls.Add(control.LightControl);
                }
            }

            this.Invalidate();
            this.Refresh();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateLightGrid();
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            _gridX = (int)numX.Value;
        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            _gridY = (int)numY.Value;
        }
    }
}
