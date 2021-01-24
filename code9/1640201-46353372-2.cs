    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                this.InitializeComponent();
                // Subscribe to the MouseMove event
                this.panel.MouseMove += this.panel_MouseMove;
            }
           
            private void panel_MouseMove(object sender, MouseEventArgs e)
            {
                // Checks if current mouse position is within the panel
                if (this.panel.Bounds.Contains(new Point(e.X, e.Y)))
                {
                    // Current mouse position within the panel
                    this.label.Show();
                    return;
                }
                
                // Current mouse position outside the panel
                this.label.Hide();
            }
        }
    }
