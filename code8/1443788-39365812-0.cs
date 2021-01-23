    public void ModifyHealth(int amount)
    {
        if (alive)
            health = health - amount;
        if (health <= 0)
        {
            Debug.Log("1: sceneToLoad = " + sceneToLoad);
            if ((sceneToLoad != "") && (SceneManager.GetSceneByName(sceneToLoad) != null))
            {
                Debug.Log("2: sceneToLoad = " + sceneToLoad);
                //Play your animation
                //Call loadNewScene after 25 seconds
                Invoke("loadNewScene",25);
            }
        }
        else
        {
            health = Mathf.Clamp(health, 0, 1000);
        }
    }
    void loadNewScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
