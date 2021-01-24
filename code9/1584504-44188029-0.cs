    public Scrollbar scrollBar;
    
    void OnEnable()
    {
        //Subscribe to the Scrollbar event
        scrollBar.onValueChanged.AddListener(scrollbarCallBack);
    }
    
    //Will be called when Scrollbar changes
    void scrollbarCallBack(float value)
    {
        Debug.Log("Scrollbar Changed: " + value);
    }
    
    void OnDisable()
    {
        //Un-Subscribe To Scrollbar Event
        scrollBar.onValueChanged.RemoveListener(scrollbarCallBack);
    }
