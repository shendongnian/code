    public static void ReadCallBack(IAsyncResult ar)
    {
        Socket listenerSocket = (Socket)ar.AsyncState;
        int received = 0;
        try
        {
            //Amount of bytes that has been sent
            received = listenerSocket.EndReceive(ar);
        }catch(Exception e)
        {
            received = 0;
        }
        if(received == 0)
        {
            listener.Close();
            return;
        }
        //Create byte array for encoding
        byte[] bytes = new Byte[received];
        Array.Copy(buffer,bytes,received);
        string recievedMessage = Encoding.ASCII.GetString(bytes);
        if (received > 0)
        {
            //do task input
            System.Diagnostics.Debug.WriteLine(recievedMessage);
        }
        //work on this
        listenerSocket.BeginReceive(buffer, 0 , bufferSize, SocketFlags.None, new AsyncCallback(ReadCallBack), listenerSocket);
    }
