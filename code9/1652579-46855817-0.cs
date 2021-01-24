            Account account = new Account();
            double amount = 0.0;
            ConsoleKeyInfo choice;
            Console.WriteLine("************************************");
            Console.WriteLine("Welcome to Bernard's Bodacious Bank!");
            Console.WriteLine("************************************");
            Console.WriteLine("We have opened your account");
            DisplayMenu();
            choice = Console.ReadKey();
            while (choice.Key != ConsoleKey.Q) {
                switch (choice.Key) {
                    case ConsoleKey.D:
                        Console.WriteLine("found d!");
                        break;
                    default:
                        Console.WriteLine("Input Error!");
                        break;
                }
            }
            account.ShowTransactions();
            Console.ReadKey();
        }
