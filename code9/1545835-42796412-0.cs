    public IEnumerable GetErrors(string propertyName)
    {
        string errorsForName;
        lock (_lock)
        {
            errorsForName = _errors.FirstOrDefault(e => e.Key == propertyName).Value;//.TryGetValue(propertyName, out errorsForName);
        }
        return new List<string> { errorsForName };
    }
