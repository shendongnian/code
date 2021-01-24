    private bool _gameEnded = false;
 
    private void EndGame(string player)
    {
       tmr1.Stop();
       _gameEnded = true;
       MessageBox.Show($"{player} perdio");
    }
