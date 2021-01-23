    static class Program
    {
        static void Main(string[] args)
        {
            // conversion_rate is a constant (at least in this program)
            const decimal conversion_rate = 1.12m;
            // decimal is a preferable type for money
            decimal dollars = 0.00m; 
            // ask until correct value is entered
            do 
            {
                Console.WriteLine("Enter in Dollars:");
            } // Console.ReadLine() - we want entire string (e.g. "5.31") not just '5' char
            while (!decimal.TryParse(Console.ReadLine(), out dollars));    
             
            // use formatting
            Console.WriteLine("Dollars: {0} are equal to {1} euros", 
              dollars, dollars * conversion_rate);
            // do you really want two pauses? (two Console.ReadLine())
            Console.ReadLine();
        }
    }
