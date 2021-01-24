        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int sum = num1 + num2;
        int diff = num1 - num2;
        int product = num1 * num2;
        
        int quo = 0;
        if (num2 != 0)
        {
            quo = num1 / num2;
        }
        Console.WriteLine($"{sum}");
        Console.WriteLine($"{diff}");
        Console.WriteLine($"{product}");
        if (num2 == 0)
        {
            Console.WriteLine("Can't divide by zero!");
        }
        else
        {
            Console.WriteLine($"{quo}");
        }
