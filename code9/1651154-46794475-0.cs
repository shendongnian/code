    static void Main(string[] args)
    {
        string menuChoice;
        string response;
        var accountList = new List<Account>();
        // Welcome/Menu screen
        Console.WriteLine("\nWelcome to your Net Worth Calculator.\n \n MENU:\n 1. Add Asset\n 2. Add Debt\n 3. View Summary");
        do
        {
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?\nPlease make a selection: ");
            menuChoice = Console.ReadLine();
            if (menuChoice == "1")
            {
                do
                { //D1
                    Account asset = new Account();
                    Console.WriteLine("\nGreat! Let's add an account.");
                    Console.WriteLine("Account name:");
                    asset.name = Console.ReadLine();
                    Console.WriteLine("Your account name is: " + asset.name);
                    Console.WriteLine("\nWhat is your current account balance with " + asset.name + "?");
                    Console.WriteLine("Balance:");
                    asset.balance = Decimal.Parse(Console.ReadLine());
                    accountList.Add(asset);
                    Console.WriteLine("Your balance with " + asset.name + " is currently $" + asset.balance + ".");
                    Console.WriteLine("\n\nWould you like to add another account? y/n");
                    response = Console.ReadLine();
                } while (response != "n");
            }
            if (menuChoice == "3")
            {
                //D3
                Console.WriteLine("Let's take a look at the accounts and balances that you've added so far:");
                Console.WriteLine($"{asset.balance} is your asset, and {debt.balance} is your debt.");
                decimal netWorth = asset.balance - debt.balance;
                Console.WriteLine(netWorth);
                Console.WriteLine($"{ asset.balance}");
                Console.WriteLine("\n\nWould you like to add another account? y/n");
                response = Console.ReadLine();
            }
