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
