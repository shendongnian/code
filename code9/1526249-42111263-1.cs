        Console.Write("Product: ");
        string product = Console.ReadLine().ToLower();
        Console.Write("City: ");
        string city = Console.ReadLine().ToLower();
        Console.Write("Price: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        double result;
        if (city == "sofia")
        {
            if (product == "coffee")
            {
                result = amount * 0.50;
                Console.WriteLine(result);
            }
        }
        Console.ReadKey();
        }
    }
