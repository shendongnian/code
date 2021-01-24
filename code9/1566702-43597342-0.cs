    using System;
     .
     .
    using System.Windows.Forms;
    
    namespace WindowsFormMyTests
    {
      public partial class Form1 : Form
      {
        int initialPanelY;
        public Form1()
        {
            InitializeComponent();
            initialPanelY = this.panelRest2.Location.Y;
        }
        private void vScrollBar1_Scroll(object  sender, ScrollEventArgs e)
        {
            int v = (sender as VScrollBar).Value; //between 1 and 100
            int hiddenPanelHeight = this.panelRest2.Size.Height - this.Size.Height;
            float moveY = (float)hiddenPanelHeight * ((float)v / 100);
            int newY = initialPanelY - (int)moveY;
            this.panelRest2.Location = new Point(this.panelRest2.Location.X, newY);
        }
      }
    }
