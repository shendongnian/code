    WpfRadioButton uIUCRadioButton = this.UIWPFDTAppSynTQClientShWindow.UIDesignSurfaceCustom.UIWPFDTAppSynTQClientInCustom2.UIUCRadioButton;
    // May not be neccesarry, I'm not sure how this is implemented.
    uIUCRadioButton.SearchProperties.Add(WpfControl.PropertyNames.ControlType, "Button");
    // Select 'UC' radio button by finding the control at index number
    uIUCRadioButton = uIUCRadioButton.FindMatchingControls()[ControlNumber]
    //Here, deal with the click logic.  Again, not sure on implementation
    uIUCRadioButton.Selected = this.Configuration_Tab_n_ClickParams.UIUCRadioButtonSelected;
        
