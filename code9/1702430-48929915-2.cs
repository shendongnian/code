    static double Divide(int a, int b)
    {
        int c = 0;
        try
        {
            c = a / b;
            return c;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Division by zero not allowed");
            return 0;
        }
    }
