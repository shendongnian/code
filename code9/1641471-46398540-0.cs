    //You dont need another parameter
    bool IsValidate(Control c)
    {
        foreach (Control x in c.Controls)
        {
            var result = IsValidate(x);
    
            //Return instantly if validation failed
            if (!result) return false;
        }
        if (c is DropDownList)
        {
            DropDownList d = (DropDownList)c;
            return !(string.IsNullOrEmpty(d.SelectedValue) || d.SelectedValue.Equals("0"));
        }
        else if (c is TextBox)
            return !string.IsNullOrEmpty(((TextBox)c).Text);
    
        //Return true if control is neither a textbox or dropdownlist
        return true;
    }
