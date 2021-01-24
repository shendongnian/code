    List<AsyncOperation> allScenes = new List<AsyncOperation>();
    const int sceneMax = 5;
    bool doneLoadingScenes = false;
    void Startf()
    {
        StartCoroutine(loadAllScene());
    }
    IEnumerator loadAllScene()
    {
        //Loop through all scene index
        for (int i = 0; i < sceneMax; i++)
        {
            AsyncOperation scene = SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
            scene.allowSceneActivation = false;
            //Add to List so that we don't lose the reference
            allScenes.Add(scene);
            //Wait until we are done loading the scene
            while (scene.progress < 0.9f)
            {
                Debug.Log("Loading scene #:" + i + " [][] Progress: " + scene.progress);
                yield return null;
            }
            //Laod the next one in the loop
        }
        doneLoadingScenes = true;
        OnFinishedLoadingAllScene();
    }
    void enableScene(int index)
    {
        //Activate the Scene
        allScenes[index].allowSceneActivation = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
    }
    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading All Scenes");
    }
