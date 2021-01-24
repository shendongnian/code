    /// <summary>
    /// Maximum time lockout for a BrokeredMessage is 5 minutes. This allows the
    /// timer to relock every 4 minutes while waiting on Task parameter to complete.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="message"></param>
    private void WaitAndRelockMessage( Task task, BrokeredMessage message )
    {
        var myTimer = new Timer( new TimerCallback( RelockMessage ), message, 240000, 240000 );
    
        task.Wait();
    
        myTimer.Dispose();
    }
    private void RelockMessage( object message )
    {
        try { ((BrokeredMessage)message).RenewLock(); }
        catch( OperationCanceledException ) { }
    }
