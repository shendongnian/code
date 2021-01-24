    public GameObject UIRootObject;
    private AsyncOperation sceneAsync;
    
    void Start()
    {
        StartCoroutine(loadScene(2));
    }
    
    IEnumerator loadScene(int index)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;
    
        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }
    
    void enableScene(int index)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;
    
    
        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(UIRootObject, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }
    
    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading Scene");
        enableScene(2);
        Debug.Log("Scene Activated!");
    }
