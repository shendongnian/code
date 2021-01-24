    {
        intNumGuesses++;
        lblNumGuesses.Text = intNumGuesses.ToString();
        bool guessed = false;
        try
        {
            intGuessedNum = Convert.ToInt32(txtGuess.Text);
            
            if (intRandomNumber - intGuessedNum < difference)
            {
                ...
            }
            else if (intRandomNumber - intGuessedNum > difference)
            {
               ...
            }
            else
            {
               ...
               guessed = true;
            }
            if ((intNumGuesses == 10}&&(!guessed))
            {
               // Show Message "max. nr. of guesses reached'
               // call method to clear values from textBoxes & enable Start-button
            }
        catch
        {
            MessageBox.Show("Input your Guess again and Integers Only.  Retry.");
            txtGuess.Focus();
        }
     }
