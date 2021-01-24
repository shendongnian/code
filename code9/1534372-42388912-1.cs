    private void OnTriggerEnter(Collider other)
    { 
        GameObject.Find("Camera (eye)").SendMessage("StopTimer");
        StartCoroutine( RestartSceneAfterDelay() ) ;
        // OR
        StartCoroutine( RestartSceneAfterDelay(5f) ) ;      
    }
