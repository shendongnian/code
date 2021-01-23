    static readonly Dictionary<Type, Func<object, ISummary>> _strategies =
            new Dictionary<Type, Func<object, ISummary>>();
    public static void Register<T>(Func<T, ISummary> strategy)
    {
        // 'strategy' method will create the concrete summary
        // for input of type 'T', but since the actual input will
        // be of unknown type ('object'), we need to cast here
        _strategies[typeof(T)] = input => strategy((T)input);
    }
    public ISummary CreateSummary(object input)
    {
        var type = input.GetType();
        Func<object, ISummary> strategy;
        if (!_strategies.TryGetValue(type, out strategy))
            throw new ArgumentException($"No strategy registered for type {type}");
        return strategy(input);
    }
