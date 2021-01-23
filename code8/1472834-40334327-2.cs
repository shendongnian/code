    static readonly string _player1_symbol = "X";
            static readonly string _player2_symbol = "O";
    
     static void CheckIfSomeoneHasWon()
            {
                string[,] userChoices = BuildUserChoices();
    
                string winner = CheckWhoWon(userChoices);
    
                if (winner != null)
                {
                    // Somebody won! Display message and start over
                }
            }
    
            private static string CheckWhoWon(string[,] values)
            {
                // Horizontal checks
                for (int i = 0; i < 3; i++)
                {
                    if (values[i, 0] == values[i, 1] && values[i, 1] == values[i, 2])
                    {
                        return (values[i, 0] == _player1_symbol) ? "player 1" : "player 2";
                    }
                }
    
                // Vertical checks
                for (int i = 0; i < 3; i++)
                {
                    if (values[0, i] == values[1, i] && values[1,i] == values[2,i])
                    {
                        return (values[i, 0] == _player1_symbol) ? "player 1" : "player 2";
                    }
                }
    
                // Diagonal checks
                if (values[0, 0] == values[1, 1] && values[1, 1] == values[2, 2])
                {
                    return (values[0, 0] == _player1_symbol) ? "player 1" : "player 2";
                }
    
                if (values[0, 2] == values[1, 1] && values[1, 1] == values[2, 0])
                {
                    return (values[1, 1] == _player1_symbol) ? "player 1" : "player 2";
                }
                // No one has won yet
                return null;
            }
    
            private static string[,] BuildUserChoices()
            {
                var values = new string[3, 3];
                values[0, 0] = button1.Text;
                values[0, 1] = button2.Text;
                values[0, 2] = button3.Text;
    // and so on...
                // If a button has not been click, they must have a unique text, like a number
    
                return values;
            }
