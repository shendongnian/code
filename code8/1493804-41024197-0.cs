    private TaskCompletionSource<bool> someEventSource = 
        new TaskCompletionSource<bool>();
    public event Action SomeEvent
    {
        add
        {
            someEventSource.Task.ContinueWith(t => value?.Invoke());
        }
        remove
        {
            throw new NotImplementedException();
        }
    }
    private void InvokeEvent()
    {
        someEventSource.TrySetResult(true);
    }
