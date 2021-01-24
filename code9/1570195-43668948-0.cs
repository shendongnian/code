    static void Main(string[] args)
    {
        var isValidMenuItem = false;
        while (!isValidMenuItem)
             isValidMenuItem = Menu();
        Console.WriteLine("Press a key to stop the program.");
        Console.ReadKey(true);
    }
    private static bool Menu()
    {
        Console.WriteLine("You have now entered the 2017 Wimbledon tournament!" + "\n" + "\n");
        Console.Write("Choose one of the 6 options:" + "\n" + "Press 1 for Default tournament:" + "\n" + "Press 2 for Women's single:" + "\n" +
            "Press 3 for Men's single:" + "\n" + "Press 4 for Women's double:" + "\n" + "Press 5 for Men's double:" + "\n" +
            "Press 6 for Mix double:" + "\n" + "Insert your choice...: ");
        // Since there are less than 10 options we can use one char.
        var userValue = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (userValue)
        {
            case '1':
                Console.WriteLine("You have entered a default tournament");
                break;
            case '2':
                Console.WriteLine("You have entered women's single");
                break;
            case '3':
                Console.WriteLine("You have entered men's single");
                break;
            case '4':
                Console.WriteLine("You have entered women's double");
                break;
            case '5':
                Console.WriteLine("You have entered men's double");
                break;
            case '6':
                Console.WriteLine("You have entered mix double");
                break;
            default:
                Console.WriteLine("Sorry! You have to choose one of the 6 tournament options");
                return false;
        }
        // Do some additional things
        return true;
    }
