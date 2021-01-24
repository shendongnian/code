      using System;
      using System.Drawing;
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
            string nTitle = textBox1.Text;
            string nText = textBox2.Text ;
            Form2 frm = new Form2(nTitle, nText);
            frm.Show();
        }
    }
    }
