    var ToggleButtonControl = (ToggleButton)ControlName; // 
    if (!_hasBeenToggled) //<--
    {
        parameterStr = "/////////////";
        //MessageBox.Show("This should pop-up only if the user never toggled the button");
    }
    else
    {
        //MessageBox.Show("The user toggle or toggle it back");
        if (ToggleButtonControl.IsChecked == false)
            parameterStr = "لا";
        else
            parameterStr = "نعم";
    }
