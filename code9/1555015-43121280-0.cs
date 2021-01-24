    public void StartGame(int maxPoints)
        {
            //playerArray[0].PlayerTurn = true; // Is it necessary?
            while (true)
            {
                for (int i = 0; i < playerArray.Length; i++)
                {
                    Player currentPlayer = playerArray[i];
                    currentPlayer.PlayerScore += rollAllDice();
                    Console.WriteLine("'{0}': {1}", currentPlayer.PlayerName, currentPlayer.PlayerScore);
                    if (currentPlayer.PlayerScore >= maxPoints)
                    {
                        Console.WriteLine("Congratulations, Player '{0}' has won by reaching {1} points.", currentPlayer.PlayerName, currentPlayer.PlayerScore);
                        return;
                    }
                }
            }
        }
