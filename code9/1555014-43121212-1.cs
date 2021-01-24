    public void StartGame(int maxPoints)
    {
        while (!gameEnded)
        {
            for (int i = 0; i < playerArray.Length; i++)
            {
               playerArray[i].PlayerScore += rollAllDice();
               Console.WriteLine("'{0}': {1}", playerArray[i].PlayerName, playerArray[i].PlayerScore);
    			
    			if(playerArray[i].PlayerScore >= maxPoints){
                    Console.WriteLine("Congratulations, Player '{0}' has won by reaching {1} points.",playerArray[i].PlayerName, playerArray[i].PlayerScore);
    				gameEnded = true;
    				break;
    			}	            
            }	
        }
    }
