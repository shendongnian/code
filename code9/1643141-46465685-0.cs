    public Button button1;
    public Button button2;
    
    bool button1Pressed = false;
    bool button2Pressed = false;
    
    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack(button1));
        button2.onClick.AddListener(() => buttonCallBack(button2));
    
    }
    
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            //Your code for button 1
            Debug.Log("Clicked: " + button1.name);
            button1Pressed = true;
        }
    
        if (buttonPressed == button2)
        {
            //Your code for button 2
            Debug.Log("Clicked: " + button2.name);
            button2Pressed = true;
        }
    }
    
    void Update()
    {
        //Check if both buttons have been pressed
        if (button1Pressed && button2Pressed)
        {
            //Do something
            Debug.Log("BOTH BUTTONS HAVE BEEN PRESSED");
    
            //Set both to false
            button1Pressed = false;
            button2Pressed = false;
        }
    }
