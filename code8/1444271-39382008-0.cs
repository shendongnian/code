    static int getInputValue()
    {
        Console.WriteLine("Enter a number: ");
        var input = Console.ReadLine();
        return int.Parse(input);
    }
    
    static bool ifPossible(int x, int y)
    {
        return x < y;
    }
    
    static void finalMethod(bool x)
    {
        if (x)
        {
            Console.Write("Success");
        }
        else
        {
            Console.Write("Fail");
        }
    }
    
    var number1 = getInputValue();
    var number2 = getInputValue();
    
    finalMethod(ifPossible(number1, number2))
