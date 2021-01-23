    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
               
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
    
            private void textBox2_MouseDown(object sender, MouseEventArgs e)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel1.Focus();
            }
    
            private void textBox3_MouseDown(object sender, MouseEventArgs e)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.Focus();
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                panel1.Visible = false;
            }
    
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                textBox3.Text = listBox2.SelectedItem.ToString();
                panel2.Visible = false;
            }      
            
            private void panel1_Leave(object sender, EventArgs e)
            {
                panel1.Visible = false;
            }
    
            private void panel2_Leave(object sender, EventArgs e)
            {
                panel2.Visible = false;
            }
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }
    }
