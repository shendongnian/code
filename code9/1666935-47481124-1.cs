    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                double[] array = new double[5] { 0.25, 0.4, 0.5, 0.6, 0.7 };
    
                double TargetNumber = Double.Parse(textBox1.Text);
    
                double[] arraySorted = array.OrderBy(x => Math.Abs(x - TargetNumber)).ToArray();
                int idx = Array.IndexOf(array,arraySorted.First());
    
                label1.Text = idx.ToString();
            }
        }
    }
