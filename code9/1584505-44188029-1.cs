    public ScrollRect scrollRect;
    
    void OnEnable()
    {
        //Subscribe to the ScrollRect event
        scrollRect.onValueChanged.AddListener(scrollbarCallBack);
    }
    
    //Will be called when ScrollRect changes
    void scrollbarCallBack(Vector2 value)
    {
        Debug.Log("ScrollRect Changed: " + value);
    }
    
    void OnDisable()
    {
        //Un-Subscribe To ScrollRect Event
        scrollRect.onValueChanged.RemoveListener(scrollbarCallBack);
    }
