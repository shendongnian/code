        string playerOne = null;
        bool validWord = false;
        do
        {
            Console.WriteLine("Okay player 1 - enter your word!");
            playerOne = Console.ReadLine();
            if (playerOne.Length <= 0) Console.WriteLine("Please enter an actual word.");
            else validWord = true;
        } while (validWord == false);
        Console.WriteLine("Excellent, I'm now going to clear this chat so player 2 can't see your word!");
        Thread.Sleep(1500);
        Console.Clear();
        Console.WriteLine("Hello Player 2! Player 1 has chosen a word, the word looks like this: ");
        Thread.Sleep(1200);
        for (int i = 0; i < playerOne.Length; i++)
        { 
            if ((i % 2) == 0) Console.Write(playerOne[i]);
            else Console.Write("*");
        }
        Console.ReadLine();
