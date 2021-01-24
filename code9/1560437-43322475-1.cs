    public class ListenerThread
    {
        // clients list/queue
        Queue<ClientConnection> m_Clients;
        // thread used to listen for new connections
        Thread m_Thread;
        Socket m_Socket;
        IPEndPoint m_LocalEndPoint;
    
        volatile bool m_IsListening;
    
        public ListenerThread(int port)
        {
            // get this machine hostname
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());  
            // resolve ip address from hostname
            IPAddress ipAddress = ipHostInfo.AddressList[0];  
            // create local end point object 
            m_LocalEndPoint = new IPEndPoint(ipAddress, port);  
        }
    
        void Listen()
        {
            // reset clients list
            m_Clients = new Queue<ClientConnection>();
            // initialize socket
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp ); 
            // bind this socket to listen for incomming connections to specified end point
            m_Socekt.Bind(localEndPoint);
            // start listening with backlog of 1337 connections
            m_Socket.Listen(1337);  
            // dont forget to dispose after socket was used to "unbind" it
            using ( m_Socket )
            {
                while ( m_IsListening )
                {
                    // while listening just accept connections and start them at another thread
                    Socket client = m_Socket.Accept();
                    if ( client != null )
                    {
                        m_Clients.Enqueue(new ClientConnection(client));
                    }
                }
            }
        }
    
        // method used to start the listening server
        public void Start()
        {
            if ( m_Thread == null )
            {
                m_Thread = new Thread(Listen);
            }
     
            m_IsListening = true;
            m_Thread.Start();
        }
    
        // method used to stop listening server
        public void Stop()
        {
            m_Listening = false;
            m_Thread.Join();
            while ( m_Clients.Count != 0 )
            {
                m_Clients.Dequeue().Kill();
            }
        }
    }
    // class used to communicate with the client
    public class ClientConnection
    {
        Socket m_Socket; // client socket
        Thread m_Thread; // communication thread
    
        volatile bool m_IsCommunicating;
    
        // this should start immediately because of the incomming connection priority
        internal ClientConnection(Socket socket)
        {
            m_Socket = socket;
            m_Thread = new Thread(Communicate);
            m_Thread.Start();
        }
    
        // loop in which you should send/receive data
        void Communicate()
        {
            while ( m_IsCommunicating )
            {
                // .. do your communication stuff
            }
        }
    
        // should be only used by ListenerThread to end communication.
        internal void Kill()
        {
            m_IsCommunicating = false;
            try
            {
                m_Thread.Join(5 * 1000);
                m_Thread.Abort();
            }
            catch(Exception ex) { /*...*/ }
        }
    }
