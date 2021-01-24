     public static string BackToMainMenu()
        {
            Console.WriteLine("Would you like to go back to the main menu? Y/N");
            return Console.ReadLine();
        }
     public static void CheckChoice(string choice)
        {
            if (choice == "y")
            {
                ///back at menu stuff goes here
            }
            if (choice == "n")
            {
                ///whatever you want to do on "n"
            }
            ///if user types anything other than y or n (could also use 'else')
            if (choice != "n" && choice != "y")
            {
                Console.WriteLine("Incorrect Input");
                ///Ask user if they want to go back to menu (again) 
                ///check their choice
                CheckChoice(BackToMainMenu());
            }
        }
