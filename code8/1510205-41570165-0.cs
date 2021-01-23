    public string BuildMethodCall(string MethodName, params object[] Args)
    {
        foreach (var arg in Args)
        {
            if (arg is DateTime)
            {
                // Do special formatting...
            }
        }
    }
