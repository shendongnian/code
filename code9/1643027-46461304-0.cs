    bool speaking = false;
    
    void Update()
    {
        //Run only if not running
        if (!speaking)
            StartCoroutine(IsSpeaking());
    
    }
