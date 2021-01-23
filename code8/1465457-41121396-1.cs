    static void Main(string[] args)
    {
    
        writeMsg(">> Server started");
        waitForConnection(true);
    }
    
    private static void run()
    {
        while (running)
        {
            try
            {
                byte[] prefBuffer = new byte[100];
                int bufferSize = clientSocket.Receive(prefBuffer);
                if (bufferSize == 0)
                {
                    throw new ApplicationException();
                }
                writeMsg(">> Data recieved from client");
                for (int i = 0; i < bufferSize; i++)
                {
                    Console.Write(Convert.ToChar(prefBuffer[i]));
                }
            }
            catch
            {
                writeMsg("Connection Lost");
                running = false;
                clientSocket.Close();
                clientListener.Stop();
                waitForConnection(false);
            }
        }
        runThread.Abort();
    }
    
    private static void waitForConnection(bool newThread)
    {
        //This is the where the error is created and it says...
        //Cannot access disposed object.
        clientListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9091);
        clientListener.Start();
        writeMsg(">> Listening for connections...");
        try
        {
            clientSocket = clientListener.AcceptSocket();
            writeMsg(">> Connection established");
            running = true;
            if (newThread)
            {
                startRunThread();
            }
        }
        catch (Exception e)
        {
            writeMsg(String.Format(">> Connection failed\n Error: {0}", e.Message));
        }
    }
