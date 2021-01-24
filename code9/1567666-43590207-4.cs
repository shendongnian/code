    public Task<T> Task
    {
        get
        {
            return _source.Task.ContinueWith(t =>
            {
                if (_capturedContext != null)
                {
                    SynchronizationContext.SetSynchronizationContext(_capturedContext);
                }
                return t.Result;
            });
        }
    }
