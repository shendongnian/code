    private double GetPackageCharge(double charge)
        
    {
    //value returning method to determine price for selected packages
    double charge = 0;
    if (internetCheckBox.Checked)
     {
    charge  = INTERNET_SPEED;
     }
    else if (photoCheckBox.Checked)
    {
    charge = PHOTO
    }
    else if (keyboardCheckBox.Checked)
    {
    charge = KEYBOARD;
    }
    else if microsoft.CheckBox.Checked)
    {
    charge = MICROSOFT;
    }
    return charge;
    }
