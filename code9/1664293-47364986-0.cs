    public Scene[] scenes;
    
    ...
 
    void initScenes()
    {   
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        scenes = new Scene[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = SceneManager.GetSceneByBuildIndex(sceneCount);
        }
    }
