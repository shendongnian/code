    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            //Called once 
            private async Task ProcessData()
            {
                int count = 0;
                while (true)
                {
                    await Task.Run
                     (
                         () =>
                         {
                             this.Invoke(new Action(() => {
                                 label2.Text = (count++).ToString();
                                 label1.Text = DateTime.Now.ToString(); }));
                             Thread.Sleep(100);
                         }
                     );
                }
                Debugger.Break(); //you will never see this hit at all
            }
            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private async void button2_Click(object sender, EventArgs e)
            {
               await ProcessData();
            }
        }
    }
