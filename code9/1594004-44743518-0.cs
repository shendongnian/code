        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //get messages asynchronously
                Task getMessagesTask = new Task(GetMessages);
                getMessagesTask.Start();
                GetOrderBookData();
                Task updateTask = new Task(UpdateOrderBook);
                //check if concurrent queue has items
                if(!concurrentQueue.IsEmpty)
                {
                    updateTask.Start();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
