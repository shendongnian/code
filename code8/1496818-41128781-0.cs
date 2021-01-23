    public string GetRadioValue(ControlCollection controls, string groupName)// return the value of the selected radio button, empty string if nothing is selected.
    {
        // using Language Intergrated Query (LINQ) in order to find the radio button that is selected in the groupName.
        var selectedRadioButton = controls.OfType<RadioButton>().FirstOrDefault(rb => rb.GroupName == groupName && rb.Checked);
        return selectedRadioButton == null ? string.Empty : selectedRadioButton.Text; //trinary operator (shortcut of an if expresison)
    }
