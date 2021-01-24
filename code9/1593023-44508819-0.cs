    public void BeginReceive()
    {
        SimNetSocket.BeginReceive(ReadBuffer, 0, ReadBuffer.Length, SocketFlags.None, EndReceive, null);
    }
    protected void EndReceive(IAsyncResult async)
    {
        string msg = "";
        int bytesRead = SimNetSocket.EndReceive(async);
        try { msg = ByteArrayToString(ReadBuffer,bytesRead); }
        catch (Exception e) { Debug.LogError(e); }
        Debug.Log("RAW RECEIVE: " + msg);
        MessageBuffer += msg;
        //ReadBuffer = new byte[1024]; //Not necessary, you can re-use the old buffer.
        BeginReceive();
    }
