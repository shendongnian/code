    using System;
    using System.Windows.Forms;
    
    namespace Intervals
    {
        public partial class Form1 : Form
        {
            static Interval ival;
            static Interval ival2;
    
            public Form1()
            {
                InitializeComponent();
    
                ival = new Interval();
    
                ival.setInterval(delegate {
                    MessageBox.Show(
                        "Hello from setInterval #1",
                        "setInterval Test",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
    
                    return 1;
                }, 2000);
    
    
                ival2 = new Interval();
                ival2.setInterval(delegate {
                    MessageBox.Show(
                        "Hello from setInterval #2",
                        "setInterval Test",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
    
                    return 1;
                }, 5000);
            }
    
            private void stopInterval_Click(object sender, EventArgs e)
            {
                ival.clearInterval();
            }
    
            private void stopInterval2_Click(object sender, EventArgs e)
            {
                ival2.clearInterval();
    
                //Or use `clearIntervalAfterNextRun()` to clear the interval after the next tick
                //ival2.clearIntervalAfterNextRun();
            }
        }
    }
