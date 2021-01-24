    void Start()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect("127.0.0.1", 1442);
        byte[] message = System.Text.Encoding.ASCII.GetBytes(JsonUtility.ToJson(new GameMessage("ship/spawn", "")));
        clientSocket.Send(message);
        Thread polling = new Thread(HandleResponse);
        polling.Start();
    }
    void HandleResponse()
    {
        while (true)
        {
            byte[] data = new byte[8056];
            int receivedDataLength = clientSocket.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
            Debug.Log(stringData);
        }
    }
