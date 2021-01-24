    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string> ();
            CancellationTokenSource cts = new CancellationTokenSource ();
            public Form1 ()
            {
                InitializeComponent ();
            }
            private void Form1_Load (object sender, EventArgs e)
            {
                Task.Factory.StartNew (ReceiveMessagesFromInternet, TaskCreationOptions.LongRunning)
                            .ContinueWith ((x) => cts.Cancel ());
                HandleMessagesAsync (cts.Token);
            }
            private void ReceiveMessagesFromInternet ()
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep (500); // for debugging only
                    messageQueue.Enqueue ("message " + i);
                }
            }
            private async void HandleMessagesAsync (CancellationToken token)  
            {
                while (true)
                {
                    string message;
                    while (messageQueue.TryDequeue (out message))
                    {
                        listBox1.Items.Add (message);
                    }
                    if (token.IsCancellationRequested)
                    {
                        listBox1.Items.Add ("nothing to do here");
                        return;
                    }
                    await Task.Delay (500);
                }
            }
        }
    }
