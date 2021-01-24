        while (true)
        {
            Console.Write("Please enter the number of dices you want to roll: ");
            string input = Console.ReadLine();
            if (input == "quit" || input == "exit") //check it immediately here 
                break;
         
            int numTries = 0; 
            if(!int.TryParse(input, out numTries)) //handle not valid number
            {
               Console.WriteLine("Not a valid number");
               continue;
            }
         
          
            RollDice(numTries);
            Console.ReadKey();
           
        }
