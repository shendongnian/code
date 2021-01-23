    string leveName = "";
    void Start()
    {
        //Get current scene name
        leveName = SceneManager.GetActiveScene().name;
    }
    
    void OnApplicationPause(bool paused)
    {
        //Save scene Name if paused, otherwise load last scene
        if (paused)
        {
            PlayerPrefs.SetString("myLastScene", leveName);
            PlayerPrefs.Save();
        }
        else
        {
            //Load last scene
            string lastScene = PlayerPrefs.GetString("myLastScene");
            SceneManager.LoadScene(lastScene);
        }
    }
     
