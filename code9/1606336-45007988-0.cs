    private void ThreadMethod()
    {
        AutoResetEvent _restEvent = new AutoResetEvent(false);
        _restEvent.Reset();
        while(true)
        {
            if(CurrentItem != null)
            {
                HandleCurrentItem();
            }
            _restEvent.WaitOne(200);   // Set a timeout in ms.
        }
    }
