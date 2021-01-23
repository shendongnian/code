    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace StackOverflow
    {    
    public partial class Form2 : Form
    {
        TextBox txtName; 
        public Form2()
        {
            InitializeComponent();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            txtName = textBox1;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName != null)
            {
                txtName.Text += button1.Text;                                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName != null)
            {
                txtName.Text += button2.Text;             
            }
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            txtName = textBox2;
        }
    }
    }
