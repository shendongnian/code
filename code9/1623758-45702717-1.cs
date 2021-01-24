    private bool _gameEnded = false;
 
    private void EndGame(string player, Timer t)
    {
       t.Stop();
       _gameEnded = true;
       MessageBox.Show($"{player} perdio);
    }
