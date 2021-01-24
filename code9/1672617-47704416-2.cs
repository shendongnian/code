    public static void Main(string[] args)
    {
        Single y = 1.0f;
        Single scalar = 0.75f;
    
        Console.WriteLine(Calculate(0.0f,y,scalar).ToString("N4"));
        Console.WriteLine(Calculate(0.5f,y,scalar).ToString("N4"));
        Console.WriteLine(Calculate(0.9f,y,scalar).ToString("N4"));
    }
    
    public static Single Calculate(Single x, Single y, Single scalar)
    {
        return x + ((y - x) * scalar);
    }
