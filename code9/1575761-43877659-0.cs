    public static void SaveHighScore(int score, string name) 
    {
        var list = LoadHighScores();
        // verify score is > first score to make sure list stays sorted
        if (list.Count > 0 && score <= list[0].Score)
            return; // invalid high score
        Player player = list.FirstOrDefault(p => p.Name == name);
        if (player != null)
        {
            list.Remove(player);
            player.Score = score;
        }
        else
            player = new Player { Name = name, Score = score };
        list.InsertAt(0, player);
        SaveHighScores(list);
    }
