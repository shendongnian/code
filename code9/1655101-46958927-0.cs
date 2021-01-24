        string playerOneWord = "";
        do
        {
            Console.WriteLine("Okay player 1 - enter your word!");
            playerOne = Console.ReadLine();
            if (playerOne == "")
            {
                Console.WriteLine("Please enter an actual word.");
            }
            else
            {
                playerOneWord = playerOne;
                validWord = true;
            }
        } while (validWord == false);
