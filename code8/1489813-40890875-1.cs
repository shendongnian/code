    public object GenerateVar(Type var)
    {
        if (var == typeof(Int32))
        {
            return 5;
        }
        else if (var == typeof(Char))
        {
            return 'a';
        }
        return null;
    }
