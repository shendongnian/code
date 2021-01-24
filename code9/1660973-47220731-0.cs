    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("Paused");
        }
        else
        {
            Debug.Log("resumed");
        }
    }
    void OnApplicationFocus(bool hasFocus)
    {
        Debug.Log("resumed");
    }
