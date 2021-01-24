    private void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter(Collider other)
    { 
        GameObject.Find("Camera (eye)").SendMessage("StopTimer");
        float secondsUntilRestart = 10;
        StartCoroutine(Utils.DoAfterDelay(secondsUntilRestart, RestartLevel));
    }
