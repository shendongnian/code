    public static long multiplyLong(decimal value, decimal multiplier)
    {
        try
        {
            return value*multiplier;
        }
        catch (OverflowException e)
        {
            Debug.Log("greater then max value");
            return decimal.MaxValue;
        }
        
    }
    
    public static long addLong(decimal value, decimal adder)
    {
        try
        {
            return value+adder;
        }
        catch (OverflowException e)
        {
            Debug.Log("greater then max value");
            return decimal.MaxValue;
        }
    }
