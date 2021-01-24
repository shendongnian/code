    using System;
    using System.Windows.Forms;
    
    namespace StackOverFlow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private async void button1_Click(object sender, EventArgs e)
            {
                var ops = await Operations.Create();
    
                if (ops.FoundServerInstanceName)
                {
                    if (ops.CheckDatabase())
                    {
                        MessageBox.Show("Ready to work with tables!!!");
                    }
                    else
                    {
                        if (ops.HasException)
                        {
                            MessageBox.Show($"Encountered the following issue(s)\n{ops.ExceptionMessage}");
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                        }
                    }
                }
            }
        }
    }
