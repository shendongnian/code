        while (true)
        {
            Console.Write("Please enter the number of dices you want to roll: ");
            string input = Console.ReadLine();
            int numTries;
            if (int.TryParse(input, out numTries))
            {
                RollDice(numTries);
            }
            else if(input == "quit" || input == "exit")
            {
                break;
            }
        }
