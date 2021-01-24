    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace StackOverFlow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                btnHp1.Click += new EventHandler(btnTest_Click);
            }       
    
            void btnTest_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
    
                if (button != null)
                {
                    MessageBox.Show(button.Name);
                }
            }
        }
    }
