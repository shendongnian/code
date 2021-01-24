    static void DoSomething<T>(T value)
    {
        if (value is int)
        {
            DoSomethingElse((value as int?).Value);
        }
        else if (value is float)
        {
            DoSomethingElse((value as float?).Value);
        }
        else
        {
            throw new Exception("No handler for type " + typeof(T).Name);
        }
    }
