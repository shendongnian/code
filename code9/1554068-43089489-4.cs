    ManualResetEvent _listenerTerminated = new ManualResetEvent(false);
    // <snip>
    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
    private void AcceptCallback(IAsyncResult ar)
    {
        // before calling EndAccept, check an event.
        if(_listenerTerminated.WaitOne(0))
            return;
        var clientSocket = listener.EndAccept(asyncResult);
    }
    // <snip>
    do
	{                
		allDone.Reset();                    
		listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
	}
	while(EventWaitHandle.WaitAny(handles) == 0);
    _listenerTerminated.Set();
	listener.Close();
