    public static int[] MoveValueToFront(this int[] values, int searchValue)
    {
        if (values == null || values.Length == 0)
        {
            return values;
        }
    
        var rest = values.TakeWhile(v => v != searchValue).ToArray();
    
        if (rest.Length == values.Length)
        {
            return values;
        }
    
        values[0] = searchValue;
        rest.CopyTo(values, 1);
    
        return values;
    }
