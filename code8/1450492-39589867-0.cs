    // Converts c to a ComboBox. If c is not a ComboBox, assigns null to cmbControl
    ComboBox cmbControl = c as ComboBox; 
    if (cmbControl != null)
    {
        if (cmbControl.SelectedItem != null)
        {
            // Do stuff here
        }
    }
    // Else it's not a ComboBox
