    class MessagesManager : IDisposable {
        // note that your ConcurrentQueue is still in play, passed to constructor
        private readonly BlockingCollection<string> MessagesQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
        public MessagesManager() {
            // start consumer thread here
            new Thread(SendLoop) {
                IsBackground = true
            }.Start();
        }
        public void PublishMessage(string Message) {
            // no need to notify here, will be done for you
            MessagesQueue.Add(Message);
        }
        private void SendLoop() {
            // this blocks until new items are available
            foreach (var item in MessagesQueue.GetConsumingEnumerable()) {
                // ensure that you handle exceptions here, or whole thing will break on exception
                TcpIpMessageSenderClient.ConnectAndSendMessage(item.PadRight(80, ' '));
                Thread.Sleep(2000); // only if you are sure this is required 
            }
        }
        public void Dispose() {            
            // this will "complete" GetConsumingEnumerable, so your thread will complete
            MessagesQueue.CompleteAdding();
            MessagesQueue.Dispose();
        }
    }
