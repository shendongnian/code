        while (true)
        {
            Console.Write("Please enter the number of dices you want to roll: ");
            string input = Console.ReadLine();
            if (input == "quit" || input == "exit") //check it immediately here 
                break;
            int numTries = Convert.ToInt32(input);
            //bool isValid = int.TryParse(input, out numTries);
            RollDice(numTries);
            Console.ReadKey();
           
        }
