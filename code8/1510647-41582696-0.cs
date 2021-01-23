    Dictionary<char, double> pizzaPrices = new Dictionary<char, double>(){
    { 'S', 6.99},{ 'M', 8.99},{ 'L', 12.50},{ 'X', 15.00}};
    
    int NumOfPizzas = 0;
    double Discount = 0.0, TotalPizzaPrice = 0.0;     
    char PizzaSizeChar;
    Console.Write("What pizza size do you want? ");        
    PizzaSizeChar = Console.ReadKey().KeyChar; // Gives you the input character
    if (pizzaPrices.ContainsKey(PizzaSizeChar))
    {
        Console.Write("How many pizzas do you want");
        NumOfPizzas = int.Parse(Console.ReadLine());
    
        // pizzaPrices[PizzaSizeChar] gives you the price of that char
        TotalPizzaPrice = pizzaPrices[PizzaSizeChar] * NumOfPizzas;
    
        Console.WriteLine("Your {0} pizza would normally be {1}", PizzaSizeChar, pizzaPrices[PizzaSizeChar].ToString("C"));
        Console.WriteLine("Your total would {0}", TotalPizzaPrice.ToString("C"));
    }
    else
    {
        Console.WriteLine("Invalid choice");
    }
