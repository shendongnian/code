    public InputField inputField;
    
    void OnEnable()
    {
        //Register InputField Events
        inputField.onEndEdit.AddListener(delegate { inputEndEdit(); });
        inputField.onValueChanged.AddListener(delegate { inputValueChanged(); });
    }
    
    //Called when Input is submitted
    private void inputEndEdit()
    {
        Debug.Log("Input Submitted");
    }
    
    //Called when Input changes
    private void inputValueChanged()
    {
        Debug.Log("Input Changed");
    }
    
    void OnDisable()
    {
        //Un-Register InputField Events
        inputField.onEndEdit.RemoveAllListeners();
        inputField.onValueChanged.RemoveAllListeners();
    }
