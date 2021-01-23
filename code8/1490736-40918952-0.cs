    protected void Page_PreRender(object sender, EventArgs e)
    {
        ListItem itemToRemove = DropDownList1.Items.FindByText("compiler"); //just want to remove this value
        if (itemToRemove != null)
        {
            DropDownList1.Items.Remove(itemToRemove);
        }
    }
