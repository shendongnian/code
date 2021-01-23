    using System;
    using System.Threading;
    using System.Windows.Forms;
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        delegate void UpdateGuItemsAsyncDelegate();
        void UpdateGuItemsAsync()
        {
          for (int i = 0; i < 100; i++)
          {
            progressBar1.PerformStep();
          }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          ThreadPool.QueueUserWorkItem(state =>
          {
            Thread.Sleep(10000);
    
            if (progressBar1.InvokeRequired)
            {
              UpdateGuItemsAsyncDelegate del = new UpdateGuItemsAsyncDelegate(UpdateGuItemsAsync);
              this.Invoke(del);
            }
            else
            {
              UpdateGuItemsAsync();
            }
          });
        }
      }
