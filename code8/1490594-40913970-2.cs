    public static T TrimValue<T>(T arg, int MaxLength)
    {
        var val = arg.ToString();
    
        var trimVal = val.Substring(0, MaxLength);
    
        return (T)Convert.ChangeType(trimVal, arg.GetType());
    }
