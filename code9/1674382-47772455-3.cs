    public event EventHandler SaveStarted;
    public event EventHandler SaveCompleted;
    
    public async Task SaveAsync()
    {
       SaveStarted?.Invoke(this, EventArgs.Empty);
    
       // .. save to disk ..
    
       SaveCompleted?.Invoke(this, EventArgs.Empty);
    }
