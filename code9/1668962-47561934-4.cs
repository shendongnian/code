    static T GetPropertyByName<T>(this object input, string name) 
    {
        return (T)input
            .GetType()
            .GetProperty(name, BindingFlags.Instance)
            .GetValue(input);
    }
