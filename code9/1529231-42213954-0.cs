    public static double Min(this double[,] values)
    {
        double min = double.MaxValue;
    
        foreach (var value in values)
        {
            if (value < min)
            {
                min = value;
            }
        }
    
        return min;
    }
