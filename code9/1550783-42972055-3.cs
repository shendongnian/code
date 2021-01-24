    private Mutex _mutex = new Mutex();
    private DateTime _lastRequest = DateTime.MinValue;
    ...   
    public async Task MyMethod()
    {
        await Task.Run(() => 
        {
            _mutex.WaitOne();
            if(DateTime.Now < _lastRequest + TimeSpan.FromSeconds(3))
                return;
            _lastRequest = DateTime.Now;
            //do stuff
            _mutex.ReleaseMutext();
        });
    }
