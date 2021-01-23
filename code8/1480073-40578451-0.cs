        double total = 0;
        double result;
        Console.Write("For how many numbers you want to do the average calculation: ");
        int a = int.Parse(Console.ReadLine());
        for (int j = 0; j < a; j++)
        {
            Console.Write("Please enter value for {0}: ", j + 1);
            total += double.Parse(Console.ReadLine());
        }
        result = total / a;
        Console.WriteLine($"Your Calculated average value is {result}");
        Console.ReadKey();
