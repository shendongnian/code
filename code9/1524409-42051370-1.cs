    public object GetValue(string parameterName)
    {
        // Do common stuff here to any parameter value type
        return Parameters[$"@{parameterName}"]?.Value;
    }
    public string GetString(string parameterName)
    {
         // Do common stuff here to string parameters only
         return (string)GetValue(parameterName);
    }
