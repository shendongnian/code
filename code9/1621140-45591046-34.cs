    using System;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    
    namespace Intervals
    {
        public partial class Form1 : Form
        {
            public System.Windows.Forms.Timer ival1;
    
            public Form1()
            {
                InitializeComponent();
    
                int A = 0;
    
                ival1 = Interval.setInterval(async delegate {
                    A++;
                    demo(A.ToString(), "Test");
                }, 5000);
            }
    
            private void stopInterval_Click(object sender, EventArgs e)
            {
                Interval.clearInterval(ival1);
            }
    
            public void demo(string message, string title)
            {
                MessageBox.Show(
                    message,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
