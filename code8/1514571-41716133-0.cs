        int total = 0;
        int converted = 0;
        //The loop begins, repeatedly asks the user for  numbers.
        while (true)
        {
            //Asks the user for numbers .
            Console.Write("Type a number:");
            string input = Console.ReadLine();
            // When user types in quit the program quits
            if (input == "quit")
            {
                break;
            }
            // When user types "done", dividing total with converted(entered numbers).
            else if (input == "done")
            {
                total /= converted;
                Console.WriteLine(total);
                continue;
            }
            // If user types a number, convert into integer and add total and converted together.
            else
            {
                try
                {
                    converted = int.Parse(input);
                    total += converted;
                    Console.WriteLine(total);
                }
                // Tells the user to type again.
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, please type again");
                }
            }
        }
