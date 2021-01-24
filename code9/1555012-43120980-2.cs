    public void StartGame(int maxPoints)
    {
        playerArray[0].PlayerTurn = true; // Not sure why you're doing this, so I'm gonna leave this here
    
        Player winner = null;
    
        while (!gameEnded)
        {
            for (int i = 0; i < playerArray.Length; i++)
            {            
                Player currentPlayer = playerArray[i];
    
                currentPlayer.PlayerScore += rollAllDice();
                Console.WriteLine("'{0}': {1}", currentPlayer.PlayerName, currentPlayer.PlayerScore);
    
                if (currentPlayer.PlayerScore >= maxPoints) 
                {
                    winner = currentPlayer;
                    gameEnded = true;
                    break;
                }
            }
        }
    
        Console.WriteLine("Congratulations, Player '{0}' has won by reaching {1} points.", winner.PlayerName, winner.PlayerScore);
    }
