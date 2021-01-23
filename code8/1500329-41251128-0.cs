    // you need to rewrite your code to get the enum
    // e.g.
    var gameMode = SceneManager.GetActiveScene().GameMode;
    
    switch (gameMode)
    {
        case GameMode.Singleplayer:
            // Specific Logic for Singleplayer
            break;
        case GameMode.Multiplayer:
            // Specific Logic for Multiplay
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
