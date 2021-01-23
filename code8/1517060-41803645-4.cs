    gateway.EnterWriteLock();
    try
    {
        poll.A = reply1;
        poll.B = reply2;
        poll.C = reply3;
        poll.D = reply4;
        poll.E = DateTime.Now.ToString("HH:mm:ss.fff");
    }
    finally
    {
        gateway.ExitWriteLock();
    }
