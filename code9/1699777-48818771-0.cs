        public static bool IsOnline(string queueName = null)
        {
            try
            {
                QueueClient queueClient = QueueClient.CreateFromConnectionString(ConnectionString, "testqueue", ReceiveMode.ReceiveAndDelete);
                queueClient.Receive(TimeSpan.Zero);
                queueClient.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
