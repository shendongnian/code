    try
    {
        var x = Divide (9, 3);
        x = Divide (14, 2.3f); 
        Divide(10, 0);  // bang!
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine(ex.Message);
    }
    
    .
    .
    .
    float Divide (float n, float d)
    {
        return n / d;
    }
