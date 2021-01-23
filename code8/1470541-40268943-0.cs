            int intResult;
            // Prompt the user for an input until they enter a number between 1 - 10
            while (!int.TryParse(Console.ReadLine(), out intResult) || intResult < 1 || intResult > 10)
            {
                Console.WriteLine("Not a valid int - try again");
            }
        Console.WriteLine("Enter another number between 1 and 10: ");
        iSecond = Convert.ToInt32(Console.ReadLine());
