    private void NewGame()
    {
        GetRandomNumber();
        buttonGuess.Enabled = true;
        label2.Text = string.Empty;
        _userguess = 11;
    }
