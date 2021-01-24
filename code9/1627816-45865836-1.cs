    private bool _busy;
    
    private void M()
    {
        if(_busy)
        {
            return;
        }
        _busy = true;
        Task.Factory.StartNew(() => {
            try
            {
                // Do work
            }
            finally
            {
                _busy = false;
            }
        }, TaskCreationOptions.LongRunning);
    }
