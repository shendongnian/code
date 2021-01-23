    using System;
    using System.Windows.Forms;
    namespace PositioningCs
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            private int top_val=0;
            private int left_val=0;
            public void setLocation(int top_val,int left_val)
            {
                  this.top_val=top_val;
                  this.left_val=left_val;
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                this.Top = top_val;
                this.Left = left_val;
            }
        }
    }
