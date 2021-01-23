    Dictionary<KeyCode, System.Action> keyCodeToFuncDic = new Dictionary<KeyCode, System.Action>();
    Array allKeyCodes;
    void Start()
    {
        //Get all codecodes
        allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
        //Register Keycodes to functios
        keyCodeToFuncDic.Add(KeyCode.Mouse0, myFunction); //Left mouse
        keyCodeToFuncDic.Add(KeyCode.Mouse1, myFunction2); //Right mouse
    }
    void myFunction()
    {
        Debug.Log("Left Mouse Clicked");
    }
    void myFunction2()
    {
        Debug.Log("Right Mouse Clicked");
    }
    void Update()
    {
        foreach (KeyCode tempKey in allKeyCodes)
        {
            //Check if any key is pressed
            if (Input.GetKeyDown(tempKey))
            {
                //Check if the key pressed exist in the dictionary key
                if (keyCodeToFuncDic.ContainsKey(tempKey))
                {
                    //Debug.Log("Pressed" + tempKey);
                    //Call the function stored in the Dictionary's value
                    keyCodeToFuncDic[tempKey].Invoke();
                }
            }
        }
    }
