    public static void findData()
    {
        Console.WriteLine("Find a number");
        string myChoice = Console.ReadLine();
        double number = -1;  
        if(!Double.TryParse(myChoice, out number))
        {
            Console.WriteLine("Invalid number");
        }
        else if (Array.IndexOf<double>(myArray, number) == -1)
        {
            Console.WriteLine("Number does not exist");
        }
        else
        {
            Console.WriteLine("Number does exist");
        }
    }
