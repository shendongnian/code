    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                timer1.Interval = 2000;
                timer1.Enabled = true;
                timer1.Start();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Stop();
                frm_newmessage frm_message = new frm_newmessage();
                frm_message.ShowDialog();
                timer1.Start();
            }
        }
    }
