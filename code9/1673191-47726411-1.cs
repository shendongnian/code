    private void btnGuess_Click(object sender, EventArgs e)
            {
                intNumGuesses++;
                lblNumGuesses.Text = intNumGuesses.ToString();
    //This is what you're looking for-v
                if(intNumGuesses==10)
                {
                    btnGuess.Enabled = false;
                    txtGuess.Enabled = false;
                    txtGuess.Text = "";
                    btnStart.Enabled = true;
                    intNumGuesses=0;
                }
    //This is what you're looking for-^
                try
                {
                    intGuessedNum = Convert.ToInt32(txtGuess.Text);
    
    
                    if (intRandomNumber - intGuessedNum < difference)
                    {
                        lblAnswer.Text = "To High";
                        lblAnswer.ForeColor = Color.Red;
                        lblAnswer.BackColor = Color.White;
                        txtGuess.Text = "";
                        txtGuess.Focus();
                    }
                    else if (intRandomNumber - intGuessedNum > difference)
                    {
                        lblAnswer.Text = "To Low";
                        lblAnswer.ForeColor = Color.Blue;
                        lblAnswer.BackColor = Color.White;
                        txtGuess.Text = "";
                        txtGuess.Focus();
                    }
                    else
                    {
                        lblAnswer.Text = "You Guessed it.";
                        lblAnswer.ForeColor = Color.Black;
                        lblAnswer.BackColor = Color.Green;
                        btnGuess.Enabled = false;
                        txtGuess.Enabled = false;
                        txtGuess.Text = "";
                        btnStart.Enabled = true;
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Input your Guess again and Integers Only.  Retry.");
                    txtGuess.Focus();
                }
            }
