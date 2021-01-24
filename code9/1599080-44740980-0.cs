    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Loops
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                    InitializeComponent();
            }
            private int lowerBounds, upperBounds, num;
            private void TextBoxUpperBounds_TextChanged(object sender, EventArgs e)
            {
                upperBounds = Convert.ToInt32(textBoxUpperBounds.Text);
            }
            private void BtnOutputValues_Click(object sender, EventArgs e)
            {
                for (num = lowerBounds; num < upperBounds; num++)
                {
                    if (num % 10 == 0)
                    {
                        MessageBox.Show(num.ToString());
                    }
                    else { }
                
                }
            }        
            private void TextBoxLowerBounds_TextChanged(object sender, EventArgs e)
            {
                lowerBounds = Convert.ToInt32(textBoxLowerBounds.Text);
            }
        }
    }
