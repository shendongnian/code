    public static FlipType GetFlipType(string flipTypeName)
    {
        FlipType parsed; // in C# 7.0 can be simplified into 'out FlipType parsed'
        if (!Enum.TryParse<FlipType>(flipTypeName, out parsed)
        {
            throw new OutOfRangeException(nameof(flipTypeName));
        } 
 
        return parsed;
    }
