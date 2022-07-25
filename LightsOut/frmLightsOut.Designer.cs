
namespace LightsOut
{
    partial class frmLightsOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lightGrid1 = new LightsOut.LightGrid();
            this.SuspendLayout();
            // 
            // lightGrid1
            // 
            this.lightGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightGrid1.GridX = 5;
            this.lightGrid1.GridY = 5;
            this.lightGrid1.Location = new System.Drawing.Point(12, 12);
            this.lightGrid1.Name = "lightGrid1";
            this.lightGrid1.Size = new System.Drawing.Size(776, 426);
            this.lightGrid1.TabIndex = 0;
            // 
            // frmLightsOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lightGrid1);
            this.Name = "frmLightsOut";
            this.Text = "Lights Out";
            this.ResumeLayout(false);

        }

        #endregion

        private LightGrid lightGrid1;
    }
}