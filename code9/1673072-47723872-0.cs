    double a;
    try
    {
        a = 1000 / 0 ;
    }
    catch (DivideByZeroException)
    {
        a = Double.PositiveInfinity;
    }
    //Other lines of code
