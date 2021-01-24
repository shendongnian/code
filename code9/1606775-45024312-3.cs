    private void MouseHookWorker(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                var event = _queue.Take(token);
                ProcessEvent(event.sender, event.e);
            }
        }
        catch (OperationCanceledException ex)
        {
        }
    }     
