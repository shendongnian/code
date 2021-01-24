            //guessing right letter code here
            if (wurds.Contains(letter))
            {
                char[] letters = wurds.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                        labels[i].Text = letter.ToString();
                }
                // determine how many letters have not been guessed yet
                int lettersNotGuessed = 0;
                foreach (Label l in labels)
                {
                    if (l.Text == "_") lettersNotGuessed++;
                }
                // Perform correct action: still more to guess or they won
                if (lettersNotGuessed == 0) {
                    MessageBox.Show("You Won!", "Correct");                    
                    ResetGame();
                    return;
                }
                else {
                    MessageBox.Show("You've guessed one letter!", "Correct");
                }    
                return;
            }
