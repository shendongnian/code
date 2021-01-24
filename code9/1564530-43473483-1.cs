    void Update () {
    //------------ CHECKING "IF RUNNING" FOR ALL ACTIONS FROM LOCAL PLAYER ---------------------- 
        if (MatchManager.GetMMInstance().Running)
        {
            //...your previous code
            //save references to Events.UnityActions
        } 
        else
        {
            ClockwiseOrbitButton.GetComponent<Button>().onClick.RemoveListener(referenseToTheAction1);
            CoClockwiseOrbitButton.GetComponent<Button>().onClick.RemoveListener(referenseToTheAction2);
            // etc.; remove all Events.UnityAction listeners from other buttons.
        }
    }
