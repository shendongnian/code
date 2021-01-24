    public class CommunicationManager
    {
        static readonly object syncRoot = new object();
    
        static CommunicationManager _Instance;
        public static CommunicationManager Instance
        {
            get
            {
                if ( _Instance == null )
                {
                    lock ( syncRoot )
                    {
                        if ( _Instance == null )
                        {
                            _Instance = new CommunicationManager();
                        }
                    }
                }
                return _Instance;
            }
        }
    
        volatile bool working = false;
    
        Queue<Message> _messages;
    
        private CommunicationManager()
        {
            _messages = new Queue<Message>();
            InitializeCommunication();
        }
    
        void InitializeCommunication()
        {
            Thread t = new Thread(CommunicationLoop);
            t.Start();
        }
    
        void CommunicationLoop()
        {
            Socket s = null;
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1337));
                working = true;
            }
            catch(Exception ex)
            {
                working = false;
            }
            while ( working )
            {
                lock ( syncRoot )
                {
                    while ( _messages.Count > 0 )
                    {
                        Message message = _messages.Dequeue();
                        MessageResult result = message.Process(s);
                        result.Notify();
                    }
                }
                Thread.Sleep(100);
            }
        }
    
        public void EnqueueMessage(Message message)
        {
            lock ( syncRoot )
            {
                _messages.Enqueue( message );
            }
        }
    }
