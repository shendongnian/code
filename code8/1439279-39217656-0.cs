    bool someBool = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            someBool = !someBool;
        }
    }
