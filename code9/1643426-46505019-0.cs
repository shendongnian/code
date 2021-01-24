    private readonly object _timeoutLock = new object();
    public bool CheckAndResetTimeout() {
        if (DateTime.UtcNow > _start + _timeout) {
            lock (_timeoutLock) {
                if (DateTime.UtcNow > _start + _timeout) {
                    _start = DateTime.UtcNow;
                    return true;
                }
            }
        }
        return false;
    }
