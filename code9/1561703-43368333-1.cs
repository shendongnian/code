    public static void Main(string[] args)
    {
        int intNr;
        double doubleNr = 0;
        while(true)
        {
            Console.WriteLine("Enter your number: ");
            string strNr = Console.ReadLine();
            int value;
            if(Int32.TryParse(strNr, out value))
            {
                doubleNr = value;
            }
            else
            {
                Console.WriteLine("Enter a valid number: ");
                continue;
            }
            if(doubleNr < 20)
            {
                Console.WriteLine("Try a higher number.");
                continue;
            }
            else if(doubleNr > 30)
            {
                Console.WriteLine("Try a lower number.");
                continue;
            }
            else 
            {
                Console.WriteLine("That is a good number."); 
                break;
            }
        }
    }
