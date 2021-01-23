    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace Login_Viper_Safe
    {
        public partial class login : Form
        {
            public login()
            {
                InitializeComponent();
            }
    
            private void bunifuThinButton22_Click_1(object sender, EventArgs e)
            {
                SlideA.Location = slideB.Location;
            }
    
            private void bunifuThinButton21_Click_1(object sender, EventArgs e)
            {
                slideB.Location = SlideA.Location;
            }
        }
    }
    
