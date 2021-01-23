    private void addEnemy()
    {
        ContentControl enemy = new ContentControl();
        enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
        AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
        AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
            random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
        playArea.Children.Add(enemy);
    }
