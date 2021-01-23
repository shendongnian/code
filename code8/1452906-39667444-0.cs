    private async void CallSaveAsync(string value)
    {
        if (RaiseBeforeSave(value))
        {
            await SaveAsync?.Invoke();
            RaiseAfterSave(value);
        }
    }
    private Func<Task> _saveAsync;
    public Func<Task> SaveAsync
    {
        get { return _saveAsync ?? DefaultSaveAsync; }
        set { _saveAsync = value; }
    }
    private async Task DefaultSaveAsync()
    {
        // Complete and return a fancy default task, like - actually saving stuff
    }
