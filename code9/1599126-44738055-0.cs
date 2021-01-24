    public void OnLevelCompleted()
    {
        // Retrieve name of current scene / level
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt( sceneName, 1 ) ; // Indicates the level is completed
    }
