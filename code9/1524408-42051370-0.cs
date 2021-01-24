    public TValue GetValue<TValue>(string parameterName)
    {
        // Do stuff here before returning the parameter value...
        return (TValue)Parameters[$"@{parameterName}"]?.Value;
    }
