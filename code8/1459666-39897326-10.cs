    protected void grid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
        GridDataItem item = (GridDataItem)e.Item;
        GridEditableItem editItem = e.Item as GridEditableItem;
        if (e.Item is GridEditableItem && e.Item.IsInEditMode) // Only when the grid is in EDIT MODE
        {
    RadComboBoxItem selectedItem = new RadComboBoxItem(); 
    RadComboBox editor= (RadComboBox)grid["drpColumn"].FindControl("ddlForEdit");
    roleName = DataBinder.Eval(myGridItem.DataItem, "drpColumn").ToString();
    editor.DataSource = Enum.GetValues(typeof(ddlElements));
    editor.DataBind();
    selectedItem = combo.FindItemByText(roleName);
    editor.SelectedIndex = selectedItem.Index;        
        }
    }
