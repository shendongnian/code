    static void Main(string[] args)
    {
        var pizzasSold = new string[7][];
        GetPizzas(pizzasSold);
            
        for (int i = 0; i < pizzasSold.Length; i++)
        {
            var dayOfWeek = ((DayOfWeek)i).ToString();
            Console.WriteLine("You sold {0} pizzas on {1}: {2}", 
                pizzasSold[i].Length, dayOfWeek, string.Join(", ", pizzasSold[i]));
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
    static void GetPizzas(string[][] array)
    {
        for (int r = 0; r < array.Length; r++)
        {
            var dayOfWeek = ((DayOfWeek)r).ToString();
            var numPizzasSold =
                    GetIntFromUser($"How many total pizzas were there for {dayOfWeek}? ",
                    "Number cannot be negative. Try Again: ", 0);
            Console.Write($"Enter all the pizzas for {dayOfWeek}, seperated by spaces: ");
            var pizzasSold = Console.ReadLine().Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            while (pizzasSold.Length != numPizzasSold)
            {
                Console.Write($"Input does not match number needed. Try Again: ");
                pizzasSold = Console.ReadLine().Split(new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
            }
            array[r] = pizzasSold;
        }
    }
