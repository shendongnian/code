    static private Game _currentGame;    
    private void ResetButton_Click(object sender, EventArgs e)
    {
        this.Hide();
        _currentGame = new Game();
        _currentGame.Show();
        this.Close();
    }
