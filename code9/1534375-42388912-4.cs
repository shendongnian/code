    private void RestartScene()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }
    private void OnTriggerEnter(Collider other)
    { 
        GameObject.Find("Camera (eye)").SendMessage("StopTimer");
        Invoke( "RestartScene", 5f ) ;
    }
