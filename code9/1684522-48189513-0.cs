    protected T GetValue<T>(T arg, List<string> item, int index)
    {
        if (arg is int)
            return (int)(object)Convert.ToInt32(item[index]);
        if (arg is string)
            return (string)(object)arg.ToString();
        if (arg is decimal)
            return (decimal)(object)Convert.ToDecimal(item[index]);
        return default(T);
    }
