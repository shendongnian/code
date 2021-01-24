    float pauseBeginTime;
    float focusTime;
    
    float totalTimeInBackground;
    
    void OnApplicationFocus(bool hasFocus)
    {
        //Detect return to game
        if (hasFocus)
        {
            Debug.Log("Focused");
    
            focusTime = Time.time;
            //Calculate how much waited in the background
            totalTimeInBackground = focusTime - pauseBeginTime;
    
            Debug.Log("Stayed in Background for " + totalTimeInBackground);
        }
    
        //Detect on-screen keyboard is enabled
        else
        {
            setExitTime();
        }
    }
    
    
    void OnApplicationPause(bool pause)
    {
        //Detect Home button on Android
        if (pause)
        {
            setExitTime();
        }
    }
    
    void setExitTime()
    {
        Debug.Log("Paused");
        pauseBeginTime = Time.time;
    }
