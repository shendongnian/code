    void Main()
    {
	    string menuChoice;
        string response;
	    var accountList = new List<Account>();
	    var debtList = new List<Debt>();
	
        do
        {
            response = "";
            Console.WriteLine("\nWelcome to your Net Worth Calculator.\n \n MENU:\n 1. Add Asset\n 2. Add Debt\n 3. View Summary\n 4. Quit");
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?\nPlease make a selection: ");
            menuChoice = Console.ReadLine();
            if (menuChoice == "1")
            {
                do
                {
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
            if (menuChoice == "2")
            {
                do
                {
			        Debt debt = new Debt();
						
                    Console.WriteLine("\nGreat! Let's add a debt.");
                    Console.WriteLine("Debt name:");
                    debt.name = Console.ReadLine();
                    Console.WriteLine("Your debt name is: " + debt.name);
                    Console.WriteLine("\nWhat is your current debt balance with " + debt.name + "?");
                    Console.WriteLine("Balance:");
                    debt.balance = Decimal.Parse(Console.ReadLine());
                    debtList.Add(debt);
                    Console.WriteLine("Your balance with " + debt.name + " is currently $" + debt.balance + ".");
                    Console.WriteLine("\n\nWould you like to add another debt? y/n");
                    response = Console.ReadLine();
                } while (response != "n");
            }
            if (menuChoice == "3")
            {
                var totalAsset = accountList.Sum(x => x.balance);
			    var totalDebt = debtList.Sum(x => x.balance);
			
                Console.WriteLine("Let's take a look at the accounts and balances that you've added so far:");
                Console.WriteLine($"{totalAsset} is your asset, and {totalDebt} is your debt.");
                decimal netWorth = totalAsset - totalDebt;
                Console.WriteLine($"Net worth: {netWorth}");
                Console.WriteLine("\n\nPress any key to return to the menu");
                Console.ReadLine();
            }
        } while (menuChoice != "4");
    }
    public class Account
    {
        public string name {get;set;}
        public decimal balance {get;set;}
    }
    public class Debt
    {
        public string name {get;set;}
        public decimal balance {get;set;}
    }
