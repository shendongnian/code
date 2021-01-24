            bool match = false;
            for (int j = 0; j < playerOneDisguised.Length; j++)
            {
                for (int y = 0; y < playerTwoGuesses.Length; y++)
                {
                    if (playerOneCharacters[j] == playerTwoGuesses[y])
                    {
                        playerOneDisguised[j] = playerTwoGuesses[y];
                        match = true;
                    }
                }
                
            }
            if (match == false) {
                
                lives = lives - 1;
            }
            // Reset it back to false
            match = false;   
