    public void Start()
    {
        SystemEvents.SessionEnded += OnSessionEnded;
    ...
    public void Stop()
    {
        SystemEvents.SessionEnded -= OnSessionEnded;
    ...
    private void OnSessionEnded(object sender, SessionEndedEventArgs eventArgs)
    {
        if (eventArgs.Reason == SessionEndReasons.SystemShutdown)
        {
            SendRequest();
        }
    }
