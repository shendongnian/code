    static public bool SendToAll(short msgType, MessageBase msg)
    {
        if (LogFilter.logDev) { Debug.Log("Server.SendToAll msgType:" + msgType); }
        bool result = true;
        // this list holds all connections (local and remote)
        for (int i = 0; i < connections.Count; i++)
        {
            NetworkConnection conn = connections[i];
            if (conn != null)
                result &= conn.Send(msgType, msg);
        }
        return result;
    }
