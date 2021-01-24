    class Program
    {
    
        static void Main(string[] args)
        {
            double total = 0;
            string choice = "y";
    
            while (choice == "y")
            {
                Console.WriteLine("Main Menu:\nChocolate\nSandwiches");
    
                int menu = int.Parse(Console.ReadLine());
    
                switch (menu)
                {
                    case 1:
                        total += chocolate();
                        break;
                    case 2:
                        total += sandwich();
                        break;
                }
                Console.WriteLine("current total: £" + total.ToString("0.00"));
                Console.WriteLine("Press 1 for main menu");
                menu = int.Parse(Console.ReadLine());
            }
        }
    
        static double chocolate()
        {
            int menu = 0;
    
            Console.WriteLine("Chocolate bar menu:\nMars bar\nSnickers\nTwix\nMilky Bar\nTurkish Delight");
    
            int chocBar = int.Parse(Console.ReadLine());
    
            Console.Clear();
            Console.WriteLine("Quantity");
    
            double quant = double.Parse(Console.ReadLine());
    
            Console.Clear();
            double cost;
            switch (chocBar)
            {
            case 1: // Mars
                cost = 0.5;
                break;
            case 2: // Snickers
                cost = 0.8;
                break;
            default:
                throw new Exception("Invalid user input");
            }
            Console.Clear();
            return quant * cost;
        }
    }
