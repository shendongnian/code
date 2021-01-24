    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach(KeyCode kCode in Enum.GetValues(typeof(KeyCode)) )
            {
                if (Input.GetKeyDown(kCode) ){
                    Debug.Log("KeyCode = " + kCode);
                    OnRadioClicked.Invoke(kCode.ToString());
                }
            }
        }
    }
