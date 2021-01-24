    using System;
    using System.Windows.Forms;
    
    namespace PassParamsFromForm2ToForm1_45997869
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Click += Button1_Click;
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                Form2 f2 = new Form2("blah blah blah");
                f2.ShowDialog();
                label1.Text = f2.returnValue;
            }
        }
    }
    
