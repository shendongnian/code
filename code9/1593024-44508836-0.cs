    protected void EndReceive(IAsyncResult async)
    {
        string msg = "";
        try 
        { 
            int received = SimNetSocket.EndReceive(async);
            var tmpArr = new byte[received];
            Buffer.BlockCopy(ReadBuffer, 0, tmpArr, 0, received);
            msg = ByteArrayToString(tmpArr); 
            Debug.Log("RAW RECEIVE: " + msg);
            MessageBuffer += msg;
            BeginReceive();
        }
        catch (Exception e) { Debug.LogError(e); }
    }
