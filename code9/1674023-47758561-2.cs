    public class Client
    {
        public int SenderPort { get; set; }
        public byte[] Buffer { get; set; }
        public string SenderHost { get; set; }
        public TcpClient SenderConnection;
        public Queue<byte[]> ReceivedTextFiles;
        public Client(int senderPort, string senderHost)
        {
            this.SenderPort = senderPort;
            this.SenderHost = senderHost;
            ReceivedTextFiles = new Queue<byte[]>();
        }
        public Task Connect()
        {
            return Task.Factory.StartNew(() =>
            {
                SenderConnection = new TcpClient();
                SenderConnection.Connect(SenderHost, SenderPort);
                Thread t = new Thread(Recieve);
                Thread t2 = new Thread(ProcessTextFiles);
                t.Start();
                t2.Start();
            });
        }
        public void Recieve()
        {
            while (true)
            {
                if (SenderConnection.Available > 0)
                {
                    lock (Buffer)
                    {
                        Buffer = new byte[SenderConnection.Available];
                        int receivedBytes = SenderConnection.Client.Receive(Buffer);
                        if (receivedBytes > 0)
                        {
                            lock (ReceivedTextFiles)
                            {
                                ReceivedTextFiles.Enqueue(Buffer);
                                Buffer = null;
                            }
                        }
                    }
                }
            }
        }
        public void ProcessTextFiles()
        {
            while (true)
            {
                byte[] textFile = null;
                lock (ReceivedTextFiles)
                {
                    if (ReceivedTextFiles.Count > 0)
                    {
                        textFile = ReceivedTextFiles.Dequeue();
                    }
                }
                //Process the file
                Thread.Sleep(1500);
            }
        }
    }
