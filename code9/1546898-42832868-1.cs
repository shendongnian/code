    public static void Main(string[] args)
    {
        //Your code goes here
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Choose your mathmetical operator:  (A)dd  (S)ubtract  (M)ultiply");
            if (Console.ReadLine() == "A")
            {
                Console.WriteLine("Enter 2 values.");
                double value1 = AskForInput<double>("Enter left value :");
                double value2 = AskForInput<double>("Enter right value :");
                Add(value1, value2);
            }
        }
    }
    
    public static TResult AskForInput<TResult>(string message)
    {
        volatile bool isValid = false;
        while(!isValid)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            try
            {   
                TResult result = (TResult)Convert.ChangeType(value, typeof(TResult));
                return result;
            }
            catch
            {
                Console.WriteLine("Input does not match requested type");
            }
        }
    }
    
    static void Add(int value1, int value2)
    {
        double result = value1 + value2;
        Console.WriteLine(result);
        Console.ReadLine();
        Console.Clear();
    }
    
    static void Subtract(int value1, int value2)
    {
        double result = value1 - value2;
        Console.WriteLine(result);
        Console.ReadLine();
        Console.Clear();
    }
    
    static void Multiply(int value1, int value2)
    {
        double result = value1 * value2;
        Console.WriteLine(result);
        Console.ReadLine();
        Console.Clear();
    }
