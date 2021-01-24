    public static string GetEnumName(Enum input)
    {
        return input.GetType().Name;
    }
    
    public static string GetName(Enum input)
    {
        return Enum.GetName(input.GetType(), input);
    }
