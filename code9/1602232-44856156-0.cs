    public Dropdown dropdown;
    
    Dropdown otherDropDown;
    void OnEnable()
    {
        //Register to onValueChanged Events
        dropdown.onValueChanged.AddListener(delegate { callBack(dropdown); });
    }
    
    void OnDisable()
    {
        //Un-Register from onValueChanged Events
        dropdown.onValueChanged.RemoveAllListeners();
    }
    
    void callBack(Dropdown currentDropdown)
    {
        //Compare dropdown by instance?
        if (currentDropdown == otherDropDown)
        {
            int value = currentDropdown.value;
        }
    
        //Compare dropdown by name
        if (currentDropdown.name == "YourDPName")
        {
            int value = currentDropdown.value;
        }
    }
