    MessageBoxResult result = MessageBox.Show("Game Over! Try again?",
        "Game Over",
        MessageBoxButtons.YesNo);
    if (result == MessageBoxResult.No)
    {
        System.Windows.Application.Current.Shutdown();
    }
    if (result == MessageBoxResult.Yes)
    {
        //Restart your game
    }
