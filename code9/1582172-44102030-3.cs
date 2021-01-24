    Dictionary<KeyCode, System.Action> keyCodeDic = new Dictionary<KeyCode, System.Action>();
    
    void Start()
    {
        //Register Keycodes to to match each function to call
        const int alphaStart = 48;
        const int alphaEnd = 57;
    
        int paramValue = 0;
        for (int i = alphaStart; i <= alphaEnd; i++)
        {
            KeyCode tempKeyCode = (KeyCode)i;
    
            //Use temp variable to prevent it from being capture
            int temParam = paramValue;
            keyCodeDic.Add(tempKeyCode, () => MethodCall(temParam));
            paramValue++;
        }
    }
    
    void MethodCall(int keyNum)
    {
        Debug.Log("Pressed: " + keyNum);
    }
    
    
    void Update()
    {
        //Loop through the Dictionary and check if the Registered Keycode is pressed
        foreach (KeyValuePair<KeyCode, System.Action> entry in keyCodeDic)
        {
            //Check if the keycode is pressed
            if (Input.GetKeyDown(entry.Key))
            {
                //Check if the key pressed exist in the dictionary key
                if (keyCodeDic.ContainsKey(entry.Key))
                {
                    //Debug.Log("Pressed" + entry.Key);
    
                    //Call the function stored in the Dictionary's value
                    keyCodeDic[entry.Key].Invoke();
                }
            }
        }
    }
