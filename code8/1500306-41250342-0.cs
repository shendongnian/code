    var clients = new List<socket>();
    
    ....
    
     private void AcceptConn(IAsyncResult iar)
        {
            try
            {
                oldConnection = (Socket)iar.AsyncState;            
                var clientSocket = (Socket)oldConnection.EndAccept(iar);
                clients.Add(clientSocket);
    ....
