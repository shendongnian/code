    Start()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }
    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        // you can query the name of the loaded scene here
    }
