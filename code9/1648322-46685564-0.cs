    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (Properties.Settings.Default.launchedFirstTime == true)
                {
                    Close();
                }
            }
    
            private void btnSubmit_Click(object sender, EventArgs e)
            {
                Properties.Settings.Default.firstTimeString = txtFirstTimeString.Text;
                Properties.Settings.Default.launchedFirstTime = true;
                Close();
            }
        }
    }
