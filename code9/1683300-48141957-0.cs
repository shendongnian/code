    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                picturboxArray = Controls.OfType<PictureBox>().Reverse().ToArray();
            }
            private int count = 0;
            PictureBox[] picturboxArray;
            public int Count
            {
                get { return count; }
                set
                {
                    if (value > 2)
                        count = 0;
                    else
                        count = value;
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                PictureBoxHandle(count);
                Count++;
            }
            public void PictureBoxHandle(int index)
            {
                foreach (Control X in this.Controls)
                {
                    if (X is PictureBox)
                    {
                        X.Visible = false;
                    }
                }
                picturboxArray[index].Visible = true;
            }
        }
    }
