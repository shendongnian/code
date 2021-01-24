    public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
    {
        ThrowIfDisposed();
        cancellationToken.ThrowIfCancellationRequested(); // an early convenience check
 
        if (millisecondsTimeout < -1)
        {
            throw new ArgumentOutOfRangeException("millisecondsTimeout");
        }
 
        if (!IsSet)
        {
        // lots of stuff here, not relevant
        }
        return true;
    }
