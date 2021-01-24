    public void OnDoSomething()
    {
        // assuming you want the first panel always activated
        bool isNextValidated = true;
    
        // basically just check each panel to see if it needs to be displayed
        foreach (var displayPanel in _panels)
        {
            // if this panel is validated then activate it
            // check to see if the next panel needs activating
            if(isNextValidated)
            {
                displayPanel.Activate();
                isNextValidated = displayPanel.Validated();
            }
            else
            {
                displayPanel.Deactive();
            }                    
        }
    }
