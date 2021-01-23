    //add Action<Intent> as and Intent as parameters
    public async Task<string> FetchAsync(string url,Action<Intent> navigationFunc,Intent intent)
    {
        string jsonString;
        ...
        navigationFunc(intent);//Invoke the action
        return jsonString;
    }
