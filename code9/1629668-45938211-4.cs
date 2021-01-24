    public void Opgooien()
    {
        Opgegooid?.Invoke(this);
        _manualResetEvent.Set();
    }
