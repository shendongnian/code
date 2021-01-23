    class Program
    {
        void Main()
        {
        	Dictionary<char, double> Prices = new Dictionary<char, double>
        	{
        		{'S', 6.99},
        		{'M', 8.99},
        		{'L', 12.50},
        		{'X', 15}
        	};
        	
            int NumOfPizzas = 0;
            double Discount = 0.0, TotalPizzaPrice = 0.0;
            string PizzaSizeAsString, NumOfPIzzasAsString;
        	
        	char PizzaSizeChar;
        	
        	Console.Write("What pizza size do you want? ");
        	PizzaSizeAsString = Console.ReadLine();
        	PizzaSizeChar = Convert.ToChar(PizzaSizeAsString);
        	
        	Console.Write("How many pizzas do you want");
        	NumOfPIzzasAsString = Console.ReadLine();
        	NumOfPizzas = Convert.ToInt32(NumOfPIzzasAsString);
        	
        	TotalPizzaPrice = Prices[PizzaSizeChar] * NumOfPizzas;
        	Console.WriteLine("Your {0} pizza would normally be {1}", PizzaSizeChar, Prices[PizzaSizeChar]);
        	Console.WriteLine("Your total would {0}", TotalPizzaPrice.ToString("C"));
        
        	Discount = GetDiscount(NumOfPizzas);
        	if (Discount > 0)
        	{
        		Console.WriteLine("Because you ordered {1} pizzas, your discount is {0}", Discount.ToString("P1"), NumOfPizzas);
        		Console.WriteLine("For a final total of {0}", (TotalPizzaPrice * (1 - Discount)).ToString("C"));
        	}	
        }
        
        public double GetDiscount(int amount)
        {
        	if(amount == 2) return 0.1;
        	if(amount == 3 || amount == 4) return 0.15;
        	if(amount >= 5) return 0.2;
        	
        	return 0;
        }
    }
