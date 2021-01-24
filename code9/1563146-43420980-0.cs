    void Start()
    {
        SceneManager.LoadScene("Scene2");
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }
    
    private void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        UnityEngine.Debug.Log("Current scene: " + SceneManager.GetActiveScene().name);
    }
