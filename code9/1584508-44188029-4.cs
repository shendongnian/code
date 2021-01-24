    public Scrollbar scrollBar;
    float lastValue = 0;
    
    void OnEnable()
    {
        //Subscribe to the Scrollbar event
        scrollBar.onValueChanged.AddListener(scrollbarCallBack);
        lastValue = scrollBar.value;
    }
    
    //Will be called when Scrollbar changes
    void scrollbarCallBack(float value)
    {
        if (lastValue > value)
        {
            UnityEngine.Debug.Log("Scrolling UP: " + value);
        }
        else
        {
            UnityEngine.Debug.Log("Scrolling DOWN: " + value);
        }
        lastValue = value;
    }
    
    void OnDisable()
    {
        //Un-Subscribe To Scrollbar Event
        scrollBar.onValueChanged.RemoveListener(scrollbarCallBack);
    }
