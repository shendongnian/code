    ConnectionInfo connectionInfo = new ConnectionInfo("192.168.2.105", 5614);
    TCPConnection serverConnection = TCPConnection.GetConnection(connectionInfo);
    MessageObject myMessageObject = serverConnection.SendReceiveObject<ImageWrap>("GetMessage", "MessageReply", 1000);
                
    if (myMessageObject != null)
    {
        Console.WriteLine(myMessageObject.Message);
    }
