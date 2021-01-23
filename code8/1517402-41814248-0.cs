        static void Main(string[] args)
    {
        Double FirstOperand;
        Double SecondOperand;
        Double Result;
        Console.Write("What is your first number?");
        FirstOperand = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("What is your second number?");
        SecondOperand = Convert.ToDouble(Console.ReadLine());
        Result = FirstOperand + SecondOperand;
        Console.Write("Result is {0}", Result);
    }
