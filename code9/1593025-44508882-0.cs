    protected void EndReceive(IAsyncResult async)
    {
        try
        {
            int byteCount = SimNetSocket.EndReceive(async);
            // For example (you didn't share ByteArrayToString(), so it's not clear
            // what encoding you're using, or if you're even processing the bytes
            // correctly. Feel free to modify as needed...just make sure you take
            // into account the byteCount value!
            string msg = Encoding.ASCII.GetString(ReadBuffer, 0, byteCount);
    
            Debug.Log("RAW RECEIVE: " + msg);
            MessageBuffer += msg;
            // There is no need to allocate a new buffer. Just reuse the one you had
            BeginReceive();
        }
        catch (IOException)
        {
            // Don't catch all exceptions. Only exceptions that should be expected
            // here would be IOException. Other unexpected exceptions should be left
            // unhandled
            Debug.LogError(e);
            // You should close the socket here. Don't try to use that connection again
        }
    }
