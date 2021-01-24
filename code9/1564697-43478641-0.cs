    public void division(int num1, int num2)
    {
        try
        {
            result = num1 / num2;
            Console.WriteLine("Result: {0}", result);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Exception caught: {0}", e);
        }
    }
