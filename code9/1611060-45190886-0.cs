    UdpClient listener = new Udpclient();
    //Socket receiver_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.11.254"), 11000);
    .
    .
    .
    public Form1()
    {
        InitializeComponent(); 
        //receiver_socket.Connect(ipep);
        Thread listeningthread = new Thread(Receive_socket_delegate);
        listeningthread.Start();         
    }
    
    private void Receive_socket_delegate()
    {
       // receiver_socket.BeginReceive(r_buff, 0, r_buff.Length, SocketFlags.None, new AsyncCallback(socket_receive_data), receiver_socket);
        while(true)
        {
        byte[] bytes = listener.Receive(ref ipep);
        ThreadPool.QueueUserWorkItem(state=>{
        socket_receive_data(bytes);
        });
        }
    }
    
    void socket_receive_data(byte[] bytes)
    {
        // Write or use your data in here "bytes"
        if (recv > 0)
        {...
        }
    }   
