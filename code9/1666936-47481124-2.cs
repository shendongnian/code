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
                Double[] array = new Double[] { 0.25, 0.4, 0.5, 0.6, 0.7 };
                Double targ = Double.Parse(textBox1.Text);
    
                Double[] arraySorted = array.OrderBy(x => Math.Abs(x - targ)).ToArray();
                Int32 idx = Array.IndexOf(array,arraySorted.First());
    
                label1.Text = idx.ToString();
    
                Double arrayValue = array[idx];
                Int32 idxLower = 0;
                Int32 idxUpper = 0;
    
                if (targ == arrayValue)
                    idxLower = idxUpper = idx;
                else
                {
                    if (targ > arrayValue)
                    {
                        idxLower = idx;
                        idxUpper = idx + 1;
                    }
                    else
                    {
                        idxLower = idx - 1;
                        idxUpper = idx;
                    }
                }
    
                label2.Text = idxLower.ToString();
                label3.Text = idxUpper.ToString();
            }
        }
    }
