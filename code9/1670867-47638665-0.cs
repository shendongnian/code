    public Button startingButton;
    public Button selectionButton;
    public Button coloringButton;
    public Button CaveButton;
    
    void OnEnable()
    {
        //Register Button Events
        startingButton.onClick.AddListener(() => buttonCallBack(startingButton));
        selectionButton.onClick.AddListener(() => buttonCallBack(selectionButton));
        coloringButton.onClick.AddListener(() => buttonCallBack(coloringButton));
        CaveButton.onClick.AddListener(() => buttonCallBack(CaveButton));
    }
    
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == startingButton)
        {
            Debug.Log("Clicked: " + startingButton.name);
            Event_Manager.OnStartGameButtonClick();
        }
    
        if (buttonPressed == selectionButton)
        {
            Debug.Log("Clicked: " + selectionButton.name);
            Event_Manager.OnStartOverButtonClick();
        }
    
        if (buttonPressed == coloringButton)
        {
            Debug.Log("Clicked: " + coloringButton.name);
            Event_Manager.OnSendAnimalButtonClick();
        }
    
        if (buttonPressed == CaveButton)
        {
            Debug.Log("Clicked: " + CaveButton.name);
            Event_Manager.OnSendAnimalButtonClick();
        }
    }
