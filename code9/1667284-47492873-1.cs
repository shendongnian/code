    public async Task<string> GetResult()
    {
      if (_cachedResult != null) return _cachedResult;
      _cachedResult = await ReallyLongRunningThingAsync();
      return _cachedResult;
    }
