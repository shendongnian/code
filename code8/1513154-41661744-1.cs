    public string start()
    {
        var response = sendRequest().ConfigureAwait(true)
                                    .GetAwaiter()
                                    .GetResult();
        System.Diagnostics.Debug.WriteLine(response);
        return "";
    }
