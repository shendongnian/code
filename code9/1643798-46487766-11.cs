    public event EventHandler OnConsoleUpdate;
    public void ConsoleUpdate()
    {
        OnConsoleUpdate?.Invoke(this, EventArgs.Empty);
    }
