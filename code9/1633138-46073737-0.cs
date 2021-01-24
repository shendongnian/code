    public void StartAsync(Action a)
    {
        a.BeginInvoke(CallBack, a); // Pass a Callback and the action itself as state
    }
    private void CallBack(IAsyncResult ar)
    {
        // In the callback you can get the delegate
        Action a = ar.AsyncState as Action;
        // and call EndInvoke on it.
        a?.EndInvoke(ar);
    }
