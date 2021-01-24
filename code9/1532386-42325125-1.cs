    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
    public partial class Form1 : Form
    {
        double height;
        double weight;
        double bmi;
        public Form1()
        {
            InitializeComponent();
        }
        private void calculate()
        {
            try
            {
                double calc = Math.Round((weight / (height * height)) * 10000, 1);
            }
            catch
            {
                bmi = 0;  // if calculation is invalid
            }
            
            
        }
        private void updateResult()
        {
            calculatedLabel.Text = String.Format(bmi.ToString(), "0,0"); ;
        }
        private void weightTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                weight = Convert.ToDouble(weightTxtbx.Text);
            }
            catch
            {
                // stop app from crashing if input is not a number
            }
            calculate();
            updateResult();
        }
        private void heightTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                height = Convert.ToDouble(heightTxtbx.Text);
            }
            catch
            {
                // stop app from crashing if input is not a number
            }
            calculate();
            updateResult();
        }
    }
    }
