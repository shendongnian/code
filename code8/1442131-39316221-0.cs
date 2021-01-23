    public Button[] Btn;
    
    void OnEnable()
    {
        //Register Button Events
        for (int i = 0; i < Btn.Length; i++)
        {
            int btIndex = i;
            Btn[i].onClick.AddListener(() => buttonCallBack(Btn[btIndex]));
        }
    }
    
    private void buttonCallBack(Button buttonPressed)
    {
        Debug.Log(buttonPressed.GetComponentInChildren<Text>().text);
    
        if (buttonPressed == Btn[0])
        {
            //Your code for button 1
        }
    
        if (buttonPressed == Btn[1])
        {
            //Your code for button 2
        }
    
        if (buttonPressed == Btn[2])
        {
            //Your code for button 3
        }
    
        if (buttonPressed == Btn[3])
        {
            //Your code for button 4
        }
    }
    
    void OnDisable()
    {
        //Un-Register Button Events
        for (int i = 0; i < Btn.Length; i++)
        {
            Btn[i].onClick.RemoveAllListeners();
        }
    }
