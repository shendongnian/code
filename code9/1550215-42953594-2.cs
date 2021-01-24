    void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
    }
    
    //Called when there is an exception
    void LogCallback(string condition, string stackTrace, LogType type)
    {
        //Send Email
    }
    
    void OnDisable()
    {
        Application.logMessageReceived -= LogCallback;
    }
