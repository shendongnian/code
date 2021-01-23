    protected void grid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
        GridDataItem item = (GridDataItem)e.Item;
        GridEditableItem editItem = e.Item as GridEditableItem;
        if (!(e.Item is GridEditableItem && e.Item.IsInEditMode))
        {
        GridDropDownListColumnEditor editor = editMan.GetColumnEditor("drpColumn") as GridDropDownListColumnEditor;
        editor.DataSource = Enum.GetValues(typeof(ddlElements));
        editor.DataBind();
        }
    }
