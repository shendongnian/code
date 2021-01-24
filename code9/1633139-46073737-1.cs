    public void StartAsync(Action a)
    {
        a.BeginInvoke(CallBack, a); // Pass a Callback and the action itself as state
    }
    private void CallBack(IAsyncResult ar)
    {
        // In the callback you can get the delegate
        Action a = ar.AsyncState as Action;
        try
        {
            // and call EndInvoke on it.
            a?.EndInvoke(ar); // Exceptions will be re-thrown when calling EndInvoke
        }
        catch( Exception ex )
        {
            Log.Error( ex, "Exception in onUpdate-Action!" );
        }
    }
