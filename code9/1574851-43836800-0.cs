    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace FinalProject
    {
    public partial class Form1 : Form
    {
       public static int operation = 0;
        public static int digits = 0;
    
        public Form1()
        {
            InitializeComponent();
        }
        // this is to make sure only one box is checked for both selections. Starts here
        private void label1_Click(object sender, EventArgs e)
        {
    
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
    
        }
    
        private void MulCB_CheckedChanged(object sender, EventArgs e)
        {
    
    
            if ( MulCB.Checked == true)
            {
                operation = 1;
                DivCB.Checked = false;
                AddCB.Checked = false;
                SubCB.Checked = false;
            }
        }
    
        private void DivCB_CheckedChanged(object sender, EventArgs e)
        {
            if (DivCB.Checked == true)
            {
                operation = 2;
                MulCB.Checked = false;
                AddCB.Checked = false;
                SubCB.Checked = false;
            }
        }
    
        private void AddCB_CheckedChanged(object sender, EventArgs e)
        {
            if (AddCB.Checked == true)
            {
                operation = 3;
                DivCB.Checked = false;
                SubCB.Checked = false;
                MulCB.Checked = false;
            }
        }
    
        private void SubCB_CheckedChanged(object sender, EventArgs e)
        {
            if (SubCB.Checked == true)
            {
                operation = 4;
                DivCB.Checked = false;
                AddCB.Checked = false;
                MulCB.Checked = false;
            }
        }
    
        private void oneDCB_CheckedChanged(object sender, EventArgs e)
        {
            if(oneDCB.Checked == true)
            {
                digits = 1;
                twoDCB.Checked = false;
                threeDCB.Checked = false;
            }
        }
    
        private void twoDCB_CheckedChanged(object sender, EventArgs e)
        {
            if ( twoDCB.Checked == true)
            {
                digits = 2;
                oneDCB.Checked = false;
                threeDCB.Checked = false;
            }
        }
    
        private void threeDCB_CheckedChanged(object sender, EventArgs e)
        {
            if (threeDCB.Checked == true)
            {
                digits = 3;
                oneDCB.Checked = false;
                twoDCB.Checked = false;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            // operations: 1. (*) 2. (/) 3. (+) 4. (-)
            // digits are as number indicates.
    
    
    
            // Second window popup.
            // it's the question form, right?
            Form2 questionForm = new Form2();
            //"Write" your settings in the other form's variables
            //You will have to write code that finds out which checkbox is which number! For now its fixed.
            questionForm.operation = 2;
            questionForm.digits = 1;
            questionForm.Show();
            //Hide Form1
            this.Hide();
        }
    }
    }
