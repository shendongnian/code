    class MessageQueue
    {
        public int MaxQueueSize { get; set; }
        private List<string> unsentMessages;
        private List<string> sentMessages;
        private object lockObject = new object();
        public MessageQueue()
        {
            MaxQueueSize = 10;
            unsentMessages = new List<string>();
            sentMessages = new List<string>();
        }
        public void AddMessage(string message)
        {
            lock (lockObject)
            {
                unsentMessages.Add(message);
            }
            if (unsentMessages.Count >= MaxQueueSize)
            {
                SendMessages();                
            }
        }
        public void SendMessages()
        {
            lock (lockObject)
            {
                // Code to send messages to server goes here
                sentMessages.AddRange(unsentMessages);
                unsentMessages = new List<string>();
            }
        }
    }
