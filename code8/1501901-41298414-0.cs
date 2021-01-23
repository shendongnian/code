    IEnumerator Start()
    {
    
        int REQ_AMOUNT = 2;
    
        for (int i = 0; i < REQ_AMOUNT; i++)
        {
            yield return StartCoroutine(GetSettings());
        }
    }
    
    IEnumerator GetSettings()
    {
        string url = RoomSettings.AbsoluteFilenamePath;
    
        if (Application.isEditor)
        {
            url = "file:///" + url;
        }
    
        var www = new WWW(url);
        yield return www;
        // Do some code, when file loaded
    }
