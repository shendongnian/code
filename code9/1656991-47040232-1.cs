    void OnEnable()
    {
        //subscribe to event
        LanguageDropdown.OnSelectedEvent += SelectAction;
    }
    
    void OnDisable()
    {
        //Un-subscribe to event
        LanguageDropdown.OnSelectedEvent -= SelectAction;
    }
    
    //This will be called when invoked
    void SelectAction(GameObject target)
    {
        Debug.Log(target.name + " was selected");
    }
