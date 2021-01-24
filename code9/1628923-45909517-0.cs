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
                checkBox1.CheckStateChanged += CheckBox1_CheckStateChanged;
            }
            private void CheckBox1_CheckStateChanged(object sender, EventArgs e)
            {
                MessageBox.Show("Input Changed!");
            }
        }
    }
