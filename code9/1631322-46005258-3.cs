    public void SetHelpText(string helpText)
    {
        HelpText = helpText;
    }
    
    public void ClearHelpText(string textToClear)
    {
        // check to see whether it has already been set to something else by another MouseEnter event...
        if (HelpText == textToClear)
        {
            HelpText = "";
        }
    }
