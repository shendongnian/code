    private void btnGuess_Click(object sender, EventArgs e)
        {
            {
                if(guess != null)
                {
                    if (guess == randNum)
                    {
                        score += 1;
                        lblScore.Text = score.ToString();
                    }
                    else if (guess != randNum)
                    {
                        score-=1;
                        lblScore.Text = score.ToString();
                    }
                    guessCount++;
                    lblguessCount.Text = guessCount.ToString();
                }
            }
        }
