    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string> ();
            public Form1 ()
            {
                InitializeComponent ();
            }
            private async void Form1_Load (object sender, EventArgs e)
            {
                var task1 = GetMessages ();
                var task2 = Task.Factory.StartNew (GetOrderBookData);
                dgOrders.DataSource = await task2;
                await Task.WhenAll (task1, task2);
                UpdateOrderBook ();
            }
            public async Task GetMessages ()
            {
                for (int i = 0; i < 10; i++)
                {
                    string message = await Task.Run (() => GetMessage (i));
                    messageQueue.Enqueue (message);
                    listBox1.Items.Add (message);
                }
            }
            private string GetMessage (int id)
            {
                Thread.Sleep (500); // simulate work
                return "some-message-" + id;
            }
            private IReadOnlyList<string> GetOrderBookData ()
            {
                Thread.Sleep (2000); // simulate work
                return new List<string> { "order 1", "order 2", "order 3" };
            }
            private void UpdateOrderBook ()
            {
                string message = null;
                string jsonString;
                while (messageQueue.TryDequeue (out jsonString))
                {
                    message += jsonString + "\r\n";
                }
                MessageBox.Show (message);
            }
        }
    }
