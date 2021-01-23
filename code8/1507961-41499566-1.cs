    string message = string.empty;
    message = "Please fill the ";
    if(string.IsNullOrEmpty(txtEYear.Text))
        {
           message = message + " txtEYear ";
           txtEYear.Focus();
        }
        if(string.IsNullOrEmpty(txtECat.Text))
        {
           message = message + " txtECat";
           txtECat.Focus();
        }
        if(string.IsNullOrEmpty(txtEID.Text))
        {
           message = message + " txtEID";
           txtEID.Focus();
        }
        
        MessageBox.Show(message+" Fields");
