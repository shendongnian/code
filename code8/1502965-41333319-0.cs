    using System;
    using System.Windows.Forms;
    namespace PositioningCs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void myButton_Click(object sender, EventArgs e)
            {
                Form2 frm2=new Form2();
                frm2.setLocation(this.Top,this.Left);
                frm2.show();
            }
        }
    }
