    private void txtGuess_TextChanged(object sender, EventArgs e)
    {
        if(txtGuess.Text != null)
            guess = Convert.ToInt32(txtGuess.Text);
    }
    private void btnGuess_Click(object sender, EventArgs e)
        {
            {
                if(guess <= 10 && guess >= 0)
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
                }else{score -=1;}
            }
        }
