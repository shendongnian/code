    public static string Replace(this string str, string[] oldValues, string newValue)
    {
        string result = str;
    
        for (int i = 0; i < oldValues.Length; i++)
        {
            result = result.Replace(oldValues[i], newValue);
        }
    
        return result;
    }
