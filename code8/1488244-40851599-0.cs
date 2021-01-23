    bool finishedFadeOut = false; // can start loading a new scene?
    bool finishedLoading = false; // can start fading in?
	internal void LoadScene(string sceneName) // pass in the scene to load
    {
        SceneFade(GetCamera(), GetCamera().backgroundColor, Color.black); // fade out
        SceneManager.LoadScene(sceneName); // load the scene
        SceneFade(GetCamera(), Color.black, GetCamera().backgroundColor); // fade in
        StartCoroutine(ManageScene()); // start the coroutine
    }
    IEnumerator ManageScene()
    {
        ...
        yield return new WaitUntil(); // wait for ... ?
    }
    private void Update()
    {
        if (...) // missing part
        {
            finishedFadeOut = true; // can start to load a new scene
        }
        if (...) // missing part
        {
            finishedLoading = true; // can start to fade in the scene
        }
    }
