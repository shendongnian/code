    bool IsClicked = false;
    protected void Button1_Click(object sender, EventArgs e)
    {
        IsClicked = true;
        RadGrid1.Rebind();
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (IsClicked && e.Item is GridDataItem)
        {
            updateDatabase(((GridDataItem)e.Item)["ColumnUniqueName"].Text);
        }
    }
    protected void updateDatabase(string field)
    {
        // update SQL
    }
