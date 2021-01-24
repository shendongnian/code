    public void AddParameter<T>(string name, ParameterValue<T> value)
    {
        _parameters[name] = new Parameter<TType>(name, value);
    }
    public ParameterValue<T> FindParameterValue<T>(string name) 
    {
        var parameter = _parameters[name];
        var parameterTyped = parameter as Parameter<TType>;
        return parameterTyped?.Value;
    }
