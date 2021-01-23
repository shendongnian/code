     void OnEnable()
     {
         SceneManager.sceneLoaded += SceneManager_sceneLoaded; ;
     }
    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SetupMenuSceneButtons();
    }
