    public int SceneIndex{
        set
        { 
            sceneIndex = value;
            sceneName= SceneManager.GetSceneAt (sceneIndex).name; }// it should always be set depending on the Scene Index
        }
    }
