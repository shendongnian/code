    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach(KeyCode kCode in Enum.GetValues(typeof(KeyCode)) ) // kCode is created
            {
                if (Input.GetKeyDown(kCode) )
                    Debug.Log("KeyCode = " + kCode);
            } kCode is removed from stack
            kCode is no longer known to the compiler
            OnRadioClicked.Invoke("My event arg");
        }
    }
