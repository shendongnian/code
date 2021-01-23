    readonly object _locker = new object();
    readonly ConcurrentDictionary<int, string> _dict = new ConcurrentDictionary<int, string>();
    public bool TryRemove(int key, string value)
    {
        var success = false;
        lock (_locker)
        {
            if (_dict.ContainsKey(key) && _dict[key] == value)
            {
                string val;
                success = _dict.TryRemove(key, out val);
            }
        }
        return success;
    }
