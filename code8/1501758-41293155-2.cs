    private T ParseEnum<T>(string str) where T : struct, IConvertible
    {
        var result = 0;
        foreach (var name in str.Split())
        {
            if (name.StartsWith("~"))
            {
                result &= ~(int)(Enum.Parse(typeof(T), name.Substring(1), true));
            }
            else
            {
                result |= (int)(Enum.Parse(typeof(T), name, true));
            }
        }
        
        return (T)(object)result;
    }
