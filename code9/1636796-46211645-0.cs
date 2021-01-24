    protected void OurterDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView.Rows)
                {
                    DropDownList innerDropdown = (DropDownList)row.FindControl("innedDropedDOwnID");
                    
                     innerDropdown .ClearSelection(); //making sure the previous selection has been cleared
                     innerDropdown .Items.FindByValue(OurterDropDown.SelectedValue).Selected = true;               
    
                }
    }
