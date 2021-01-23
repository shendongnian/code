    void CheckCurrentLevel()
    {
        for (int i = 1; i < LevelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level" + i)
            {
                CurrentLevel = i;
                SaveMyGame();
            }
        }
    }
