    class MessageQueue
    {
        public int MaxQueueSize
        {
            get { return maxQueueSize; }
            set
            {
                lock (lockObject)
                {
                    // Setting this to < 1 means messages will not be sent automatically
                    // (the calling application must call 'SendMessages' itself)
                    if (value < 1) value = int.MaxValue;
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
            lock (lockObject)
            {
                var messagesToSend = new List<string>();
                do
                {
                    // Send messages in batches no larger than 'MaxQueueSize'
                    messagesToSend = unsentMessages.Take(MaxQueueSize).ToList();
                    unsentMessages = unsentMessages.Skip(MaxQueueSize).ToList();
                    // Code to send messages to server goes here:
                    // RemoteApplication.WebApi.LogMessages(messagesToSend);
                } while (unsentMessages.Any());
                
                sentMessages.AddRange(unsentMessages);
                unsentMessages = new List<string>();
            }
        }
    }
