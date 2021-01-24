    Thread socketThread;
    
    void Start()
    {
        socketThread = new Thread(doForever);
        socketThread.IsBackground = true;
        socketThread.Start();
    }
    
    void doForever()
    {
    
        while (true)
        {
            //freeze frame
            gameStatus = GameStatus.PAUSED;
            //ping
            writeSocket("ping");
    
            gameStatus = GameStatus.RUNNING;
            //calculation
    
            //pong
            string pongValue = socket_reader.ReadLine();
        }
    }
