    public UserConnection(TcpClient client) {
        clientInfo = client;
        //clientInfo.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(StreamReceiver), null);
        var strm = clientInfo.GetStream();
        BinaryFormatter formatter = new BinaryFormatter();
        var mydat = (UserDTO)formatter.Deserialize(strm);
    }
