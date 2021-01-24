    private static void quickgame()    ---- Game carried out
    {
        // All other code....
        bool anyPlayerWon = false;
        int totalThrows = 0;
        while(!anyPlayerWon)
        {
            totalThrows += 1;
            for (int i = 0; i < 2; i++)
            {
                myDie[i].roll();
                Console.WriteLine("{0} Rolled:{1} on the first dice", 
                    player1[i].GetName(), myDie[i].GetTopNumber());
                Console.WriteLine("{0} Rolled:{1} on the second dice", 
                    player1[i].GetName(), myDie[i].GetTopNumber1());
                Console.WriteLine("{0} Rolled:{1} on the third dice", 
                    player1[i].GetName(), myDie[i].GetTopNumber2());
                Console.WriteLine("{0} Rolled:{1} on the fourth dice", 
                    player1[i].GetName(), myDie[i].GetTopNumber3());
                Console.WriteLine("{0} Rolled:{1} on the fifth dice", 
                    player1[i].GetName(), myDie[i].GetTopNumber4());
                myDie[i].points();                    
                Console.WriteLine("\t\t\t\t\tTotal Throws:{0}\n ----------------    --------------------------------------", totalThrows);
                var totalScore = myDie[i].TotalScore;
                if(totalScore >= 25)
                {
                    anyPlayerWon = true;
                    Console.WriteLine("This Player Won the game");
                    break;
                }
            }
        }
    }
