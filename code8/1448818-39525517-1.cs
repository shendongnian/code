    Byte output;
    try
    {
        checked
        {
            Byte a=200;
            Byte b=200
            output = (a+b);
        }
    }
    catch(OverflowException e)
    {
        output = Byte.MaxValue;
    }
    Console.WriteLine(output);
