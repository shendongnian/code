    using System;
    using System.Windows.Forms;
    
    namespace Intervals
    {
        public partial class Form1 : Form
        {
            Interval ival1 = new Interval();
            private int _A;
    
            public int A
            {
                get { return _A; }
                set {
                    _A = value;
    
                    if (value == 3) {
                        if (ival1 != null) {
                            MessageBox.Show(
                                "changeInterval Triggered",
                                A.ToString(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            ival1.changeInterval(1000);
                        }
                    }
    
                    if (value >= 10)
                    {
                        if (ival1 != null)
                        {
                            MessageBox.Show(
                                "clearInterval Triggered",
                                A.ToString(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            ival1.clearInterval();
                        }
                    }
                }
            }
    
            public Form1()
            {
                InitializeComponent();
    
                int interval = 5000;
    
                ival1.setInterval(delegate {
                    A++;
    
                    MessageBox.Show(
                        A.ToString(),
                        "A",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }, interval);
            }
    
            private void stopInterval_Click(object sender, EventArgs e)
            {
                ival1.clearInterval();
            }
        }
    }
