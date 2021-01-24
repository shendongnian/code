    var checkBoxes = new List<CheckBox>();
    checkBoxes.Add(boxAdobeReader); 
    ... // add the others. 
    private void UpdateMasterCheckBoxState(){ 
       masterButton.IsChecked = checkboxes.Any((cbox) => cbox.IsChecked == true ); 
    }
    private void anyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        UpdateMasterCheckBoxState();
    }
