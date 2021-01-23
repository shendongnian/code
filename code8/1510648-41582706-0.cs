     static void Main(string[] args)
        {
    
        char[] PizzaSizes = new char[] { 'S', 'M', 'L', 'X' };
        double[] PizzaPrices = new double[] { 6.99, 8.99, 12.50, 15.00 };
        int index = 0, NumOfPizzas = 0;
        double Discount = 0.0, TotalPizzaPrice = 0.0;
        string PizzaSizeAsString, NumOfPIzzasAsString;
        char PizzaSizeChar;
        Console.Write("What pizza size do you want? ");
        PizzaSizeAsString = Console.ReadLine();
        PizzaSizeChar = Convert.ToChar(PizzaSizeAsString);
    	index =   Array.IndexOf(PizzaSizes, PizzaSizeChar);
        Console.Write("How many pizzas do you want");
        NumOfPIzzasAsString = Console.ReadLine();
        NumOfPizzas = Convert.ToInt32(NumOfPIzzasAsString);
        foreach (char PizzaSize in PizzaSizes)
    
            if (PizzaSize == PizzaSizeChar)
            {
                    TotalPizzaPrice = (PizzaPrices[index] * NumOfPizzas);
                    Console.WriteLine("Your {0} pizza would normally be {1}",      PizzaSize, PizzaPrices[index].ToString("C"));
                    Console.WriteLine("Your total would {0}", TotalPizzaPrice.ToString("C"));
            }
        if (NumOfPizzas == 2)
        {
            Discount = 0.10;
            Console.WriteLine("Because you ordered {1} pizzas, your discount is {0}", Discount.ToString("P1"), NumOfPizzas);
            Console.WriteLine("For a final total of {0}", (TotalPizzaPrice * (1 - Discount)).ToString("C"));
        }
        if (NumOfPizzas == 3 || NumOfPizzas == 4)
        {
            Discount = 0.15;
            Console.WriteLine("Because you ordered {1} pizzas, your discount is {0}", Discount.ToString("P1"), NumOfPizzas);
            Console.WriteLine("For a final total of {0}", (TotalPizzaPrice * (1 - Discount)).ToString("C"));
        }
    
        if (NumOfPizzas >= 5)
        {
            Discount = 0.20;
    
    
            Console.WriteLine("Because you ordered {1} pizzas, your discount is {0}", Discount.ToString("P1"), NumOfPizzas);
            Console.WriteLine("For a final total of {0}", (TotalPizzaPrice * (1 - Discount)).ToString("C"));
        }
    	}
    	
