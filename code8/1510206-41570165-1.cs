    public string BuildMethodCall(string MethodName, params object[] Args)
    {
        var newArgs = Args.Select(arg => arg is DateTime ? arg.ToString() : arg).ToArray();
        // New array has original arguments with date time arguments string formatted...
    }
