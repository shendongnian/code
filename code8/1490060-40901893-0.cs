    string GetNextSceneName()
    {
        var activeSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneBuildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            return SceneManager.GetSceneByBuildIndex(activeSceneBuildIndex + 1).name;
        }
        else
        {
            return string.Empty;
        }
    }
