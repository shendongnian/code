    public event EventHandler OnConsoleUpdate;
    public void Consoleupdate()
    {
        OnConsoleUpdate?.Invoke(this, EventArgs.Empty);
    }
