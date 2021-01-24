    class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            List<string> lBag = new List<string>();
            bool bQuit = false;
            int iChoice = -1;
            string sIn = string.Empty;
            while (!bQuit)
            {
                sIn = Console.ReadLine();
                if (!Int32.TryParse(sIn, out iChoice) || !(iChoice >= 1 && iChoice <= 3))
                {
                    Console.WriteLine("\t Invalid input. Try again:");
                    PrintMenu();
                    continue;
                }
                switch (iChoice)
                {
                    case 1:
                        Console.WriteLine("\t Insert the item you want to add:");
                        lBag.Add(Console.ReadLine());
                        Console.WriteLine("\t Item added successfully.");
                        PrintMenu();
                        break;
                    case 2:
                        Console.WriteLine(string.Format("\t Current bag: [{0}]\n", string.Join(", ", lBag)));
                        PrintMenu();
                        break;
                    case 3:
                        Console.WriteLine("\t Quitting...");
                        bQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("\n Please choose one of the options below:");
            Console.WriteLine("\t [1] Add item to bag");
            Console.WriteLine("\t [2] Display the bag");
            Console.WriteLine("\t [3] Quit");
        }
    }
