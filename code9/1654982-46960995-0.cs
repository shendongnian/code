    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        var jsonLine = JsonConvert.SerializeObject(new {
            logLevel,
            eventId,
            parameters = (state as IEnumerable<KeyValuePair<string, object>>)?.ToDictionary(i => i.Key, i => i.Value),
            message = formatter(state, exception),
            exception = exception?.GetType().Name
        });
        // store the JSON log message somewhere
        Console.WriteLine(jsonLine);
    }
