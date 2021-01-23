    protected void NameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            DropDownList NameSelect = pickupView.FindControl("NameSelect") as DropDownList;
            TextBox nameBox = pickupView.FindControl("nameBox") as TextBox;
            TextBox phoneBox = pickupView.FindControl("phoneBox") as TextBox;
            TextBox DriversBox = pickupView.FindControl("DriversBox") as TextBox;
    
    
            nameBox.Text = NameSelect.SelectedItem.ToString();
            string[] selectedValues = NameSelect.SelectedValue.Split(',');
            phoneBox.Text = selectedValues[0];
            DriversBox.Text = selectedValues[1];
    
        }
