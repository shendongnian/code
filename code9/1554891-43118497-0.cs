    while (!MessagesQueue.IsEmpty)
            {
                string message;
                bool isRemoved = MessagesQueue.TryDequeue(out message);
                if (isRemoved)
                    localMessagesQueue.Enqueue(message);
            }
             
            //<<--- what happens if another thread enqueues a message here?
            while (localMessagesQueue.Count() != 0)
            {
                TcpIpMessageSenderClient.ConnectAndSendMessage(localMessagesQueue.Dequeue().PadRight(80, ' '));
                Thread.Sleep(2000);
            }
