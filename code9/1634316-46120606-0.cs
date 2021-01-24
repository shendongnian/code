    public void Add(string key, object value)
    {
      if (_dict == null)
      {
        _dict = new Dictionary<string, object>();
      }
    
      _dict.Add(key, value);
    }
    
    public bool TryGetValue(string key, out object value)
    {
      if (_dict != null)
      {
        return _dict.TryGetValue(key, out value);
      }
    
      value = null;
      return false;
    }
