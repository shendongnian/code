    public static void Main(string[] args)
    {
        //Your code goes here
        //while (true)
        {
            Console.WriteLine("Choose your mathmetical operator:  (A)dd  (S)ubtract  (M)ultiply");
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
        bool isValid = false;
        TResult result = default(TResult);
        while(!isValid)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            try
            {   
                result = (TResult)Convert.ChangeType(value, typeof(TResult));
                isValid = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Input does not match requested type");
            }
        }
        return result;
    }
    
    static void Add(double value1, double value2)
    {
        double result = value1 + value2;
        Console.WriteLine(result);
    }
    
    static void Subtract(double value1, double value2)
    {
        double result = value1 - value2;
        Console.WriteLine(result);
    }
    
    static void Multiply(double value1, double value2)
    {
        double result = value1 * value2;
        Console.WriteLine(result);
    }
