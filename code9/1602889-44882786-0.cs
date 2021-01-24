    enum Country { Spain, USA, Japan };
    static void Main(string[] args)
    {
        Country country;
        Console.WriteLine("Enter the number of country\n 1.Spain \n 2.The USA \n 3.Japan");
        string input = Console.ReadLine();
        bool sucess = Enum.TryParse<Country>(input, out country);
    
        if (!sucess)
        {
            Console.WriteLine("entry {0} is not a valid country", input);
            return;
        }
    
        switch (country)
        {
            case Country.Spain:
                Console.WriteLine("Its in Europe");
                break;
            case Country.USA:
                Console.WriteLine("Its in North America");
                break;
            case Country.Japan:
                Console.WriteLine("Its in Asia");
                break;
        }
        Console.ReadKey();
    }
