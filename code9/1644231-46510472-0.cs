    public Text text;
    float currentTime = 0;
    private bool skipFrame = false;
    
    void Update()
    {
        //Add only when we don't need to skip frame
        if (!skipFrame)
        {
            currentTime += Time.unscaledDeltaTime;
            text.text = currentTime.ToString();
        }
    
        //We need to skip frame. Don't use Time.unscaledDeltaTime this frame
        else
        {
            skipFrame = false;
            Debug.LogWarning("Filtered accumulated Time when Paused: " + Time.unscaledDeltaTime);
        }
    }
    
    
    void OnApplicationFocus(bool hasFocus)
    {
        //Enable skipFrame when focoused in app
        if (hasFocus)
        {
            //Debug.Log("Has focus");
            skipFrame = true;
        }
    }
    
    void OnApplicationPause(bool pauseStatus)
    {
        //Enable skipFrame when coming back from exiting app
        if (!pauseStatus)
        {
            //Debug.Log("UnPaused");
            skipFrame = true;
        }
    }
