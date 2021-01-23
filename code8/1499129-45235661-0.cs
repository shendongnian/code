        System.Threading.Thread SocketThread;
    volatile bool keepReading = false;
    
    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        startServer();
    }
    
    void startServer()
    {
        SocketThread = new System.Threading.Thread(networkCode);
        SocketThread.IsBackground = true;
        SocketThread.Start();
    }
    
    
    
    private string getIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
            }
    
        }
        return localIP;
    }
    
    
    Socket listener;
    Socket handler;
    
    void networkCode()
    {
        string data;
    
        // Data buffer for incoming data.
        byte[] bytes = new Byte[1024];
    
        // host running the application.
        Debug.Log("Ip " + getIPAddress().ToString());
        IPAddress[] ipArray = Dns.GetHostAddresses(getIPAddress());
        IPEndPoint localEndPoint = new IPEndPoint(ipArray[0], 1755);
    
        // Create a TCP/IP socket.
        listener = new Socket(ipArray[0].AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
    
        // Bind the socket to the local endpoint and 
        // listen for incoming connections.
    
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);
    
            // Start listening for connections.
            while (true)
            {
                keepReading = true;
    
                // Program is suspended while waiting for an incoming connection.
                Debug.Log("Waiting for Connection");     //It works
    
                handler = listener.Accept();
                Debug.Log("Client Connected");     //It doesn't work
                data = null;
    
                // An incoming connection needs to be processed.
                while (keepReading)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    Debug.Log("Received from Server");
    
                    if (bytesRec <= 0)
                    {
                        keepReading = false;
                        handler.Disconnect(true);
                        break;
                    }
    
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
    
                    System.Threading.Thread.Sleep(1);
                }
    
                System.Threading.Thread.Sleep(1);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
    
    void stopServer()
    {
        keepReading = false;
    
        //stop thread
        if (SocketThread != null)
        {
            SocketThread.Abort();
        }
    
        if (handler != null && handler.Connected)
        {
            handler.Disconnect(false);
            Debug.Log("Disconnected!");
        }
    }
    
    void OnDisable()
    {
        stopServer();
    }
