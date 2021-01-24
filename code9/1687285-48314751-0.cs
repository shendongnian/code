    private int GetColumnIndexRad(Telerik.Web.UI.RadGrid grid, string colName)
    {
        foreach (GridColumn column in grid.MasterTableView.Columns)
        {
            if (column.UniqueName.ToLower().Trim() == colName.ToLower().Trim())
            {
                return column.OrderIndex - 1;
            }
        }
        return -1;
    }
