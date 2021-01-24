    class MessagesManager {
        private readonly AutoResetEvent messagesAvailableSignal = new AutoResetEvent(false);
        private readonly ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        public void PublishMessage(string Message) {
            messageQueue.Enqueue(Message);
            messagesAvailableSignal.Set();
        }
        public void SendMessageToTcpIP() {
            while (true) {
                messagesAvailableSignal.WaitOne();
                while (!messageQueue.IsEmpty) {
                    string message;
                    if (messageQueue.TryDequeue(out message)) {
                        TcpIpMessageSenderClient.ConnectAndSendMessage(messageQueue.TryDequeue().PadRight(80, ' '));
                    }
                }
            }
        }
    }
