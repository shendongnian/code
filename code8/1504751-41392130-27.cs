    public Dropdown dropdown;
    void OnEnable()
    {
        //Register to onValueChanged Events
    
        //Callback with parameter
        dropdown.onValueChanged.AddListener(delegate { callBack(); });
    
        //Callback without parameter
        dropdown.onValueChanged.AddListener(callBackWithParameter);
    }
    
    void OnDisable()
    {
        //Un-Register from onValueChanged Events
        dropdown.onValueChanged.RemoveAllListeners();
    }
    
    void callBack()
    {
    
    }
    
    void callBackWithParameter(int value)
    {
    
    }
