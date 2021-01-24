    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            public static extern bool LockWorkStation();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                LockWorkStation();
            }
        }
    }
