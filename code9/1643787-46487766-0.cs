    public event EventHandler OnConsoleUpdate;
    public void Consoleupdate()
    {
        if (OnConsoleUpdate != null)
            OnConsoleUpdate(this, EventArgs.Empty);
    }
