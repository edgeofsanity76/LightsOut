using System;

namespace LightsOut
{
    /// <summary>
    /// Represents a single light. When instantiated will set it's position within the grid base on it's give X/Y position. Will invoke a IsClicked event when light is clicked on.
    /// </summary>
    /// <typeparam name="TControl">Any windows form control</typeparam>
    public class Light<TControl> where TControl : System.Windows.Forms.Control
    {
        public int PosX { get; }
        public int PosY { get; }

        public readonly TControl LightControl;

        public bool IsOn { get; internal set; }

        public delegate void IsClickedHandler(int posX, int posY);
        public event IsClickedHandler IsClicked;

        public void Toggle()
        {
            IsOn = !IsOn;
            LightControl.BackColor = this.IsOn ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray;
        }

        public Light(int posX, int posY)
        {
            if (posX < 0 || posY < 0)
                throw new Exception("Light position cannot be negative");
            
            PosX = posX;
            PosY = posY;

            LightControl = Activator.CreateInstance<TControl>();
            LightControl.Size = new System.Drawing.Size(50, 50);
            LightControl.Text = string.Empty;
            LightControl.Click += ControlClick;
            LightControl.Left = PosX * 50;
            LightControl.Top = PosY * 50;
            LightControl.BackColor = System.Drawing.Color.Gray;
        }

        private void ControlClick(object sender, EventArgs e)
        {
            Toggle();
            IsClicked?.Invoke(PosX, PosY);
        }
    }
}