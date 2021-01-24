    Console.Write("Do you want to play rock, paper, scissors? ");
    string playerChoice = Console.ReadLine();
    playerChoice = playerChoice.ToUpper();
    
    
    Random r = new Random();
    int computerChoice = r.Next(1, 4);
    
    //new variable for holding the player's input for rock/paper/scissor
    string playerThrowChoice;
    do
    {
        if (computerChoice == 1)
        {
          Console.WriteLine("Computer chose Rock");
          Console.Write("Player choice: type 1, 2, or 3 (1=rock 2=paper 3=scissors): ");
          playerThrowChoice = Console.ReadKey();
    
         //beginning of switch
         //notice we are using our new variable here
         switch (playerThrowChoice )
         {
             case "1":
                 Console.WriteLine("/nIt is a tie!");
                 break;
             case "2":
                 Console.WriteLine("/nYou win! Paper covers rock!");
                 break;
             case "3":
                 Console.WriteLine("/nComputer wins! Rock crushes scissors!");
                 break;
             }//end of switch
     }
    
    /// ....the rest of your logic
