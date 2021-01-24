    public ScrollRect scrollRect;
    
    void OnEnable()
    {
        //Subscribe to the ScrollRect event
        scrollRect.onValueChanged.AddListener(scrollRectCallBack);
    }
    
    //Will be called when ScrollRect changes
    void scrollRectCallBack(Vector2 value)
    {
        Debug.Log("ScrollRect Changed: " + value);
    }
    
    void OnDisable()
    {
        //Un-Subscribe To ScrollRect Event
        scrollRect.onValueChanged.RemoveListener(scrollRectCallBack);
    }
