    Dictionary<string,Action<object>> dict;
    public Action<object> GetFunction(string key)
    {
        return dict[key];
    }
    public void CallFunction(string key, object parameter)
    {
        dict[key](parameter);
    }
