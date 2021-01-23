    protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)//the grid is about to Edit.
        {
            GridEditFormItem item = (GridEditFormItem)e.Item;
            RadComboBox combo = (RadComboBox)item.FindControl("HardCoded");
            combo.SelectedValue = "Something";
        }
    }
