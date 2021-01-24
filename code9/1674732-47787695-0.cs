    protected void dropdownlist1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dropdownlist1.SelectedValue == "No")
        {
           RequiredFieldValidator1.Enabled = true;
        }
        else if(dropdownlist1.SelectedValue == "Yes")
        {
           RequiredFieldValidator1.Enabled = false;
        }
    }
