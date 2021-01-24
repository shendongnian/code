    class Cancel
    {      
     public void cancelTask(CancellationTokenSource source )
        {
            source.Cancel();
        }
    }
