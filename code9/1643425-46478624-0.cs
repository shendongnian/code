    static object TimerLock = new object();
    static bool CheckAndResetTimeout()
    {
        lock (TimerLock)
        {
            if (DateTime.UtcNow > _start + _timeout)
            {
                _start = DateTime.UtcNow;
                return true;
            }
            return false;
        }
    }
