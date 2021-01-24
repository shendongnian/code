    public void DoSomething(string param1, Type param2)
    {
        if (param1 == null)
            throw new ArgumentNullException(nameof(param1));
        if (param2 == null)
            throw new ArgumentNullException(nameof(param2));
        // param1 and param2 can now be used safely because they cannot be null
    }
