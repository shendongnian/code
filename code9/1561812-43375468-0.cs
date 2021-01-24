    IAsyncResult asyncResult=null;
    while(!_abort.WaitOne(0))
    {
        if(asyncResult==null)
        asyncResult=_tcpListener.BeginAcceptTcpClient(null, null);
        
        var waitResult=asyncResult.AsyncWaitHandle.WaitOne(1000);
        if(!waitResult) continue;
        var tcpClient=_tcpListener.EndAcceptTcpClient(asyncResult);
        asyncResult=null;
        _newClientHandler(tcpClient);
    }
