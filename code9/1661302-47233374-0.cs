    public void GameLoop(Random dice) 
    {
        int randomNum = 0; 
        int turn = 0;
        while(true)
        {
             randomNum = dice.Next(1,7); //next turn roll
             Console.WriteLine(string.Format("Player {0} rolled a {1}", turn%2 + 1, randomNum));
             if(!CheckForReroll(randomNum)) // if it's a reroll don't change player's turns
             {
                 turn++;
             }
             
             if(turn == 10) break; //made up rules to stop at turn 10 so we don't loop infinitely
        }
    }
    public bool CheckForReroll(int randomNum)
    {
        return randomNum == 6;
    }
