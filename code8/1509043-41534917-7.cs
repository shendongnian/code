    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
    
               Class1.RemoveFromDatabase(Convert.ToInt16(textBox1.Text), listBox1);
    
            }
        }
    }
