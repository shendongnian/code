    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsTestMove
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_LocationChanged(object sender, EventArgs e)
            {
                var loc = this.Location;
                this.Text = loc.X + " " + loc.Y;
            }
        }
    }
