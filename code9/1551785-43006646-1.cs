    class MessageQueue
    {
        public int MaxQueueSize
        {
            get { return maxQueueSize; }
            set
            {
                lock (lockObject)
                {
                    if (value < 1) value = 1;
                    maxQueueSize = value;
                }
            }
        }
        private int maxQueueSize;
        private List<string> unsentMessages;
        private List<string> sentMessages;
        private readonly object lockObject = new object();
        public MessageQueue(int maxQueueSize)
        {
            MaxQueueSize = maxQueueSize;
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
            // Code to send messages to server goes here
            lock (lockObject)
            {
                sentMessages.AddRange(unsentMessages);
                unsentMessages = new List<string>();
            }
        }
    }
