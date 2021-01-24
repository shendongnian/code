    //Event Triggering
    this.gridControl1.QueryCellInfo += GridControl_QueryCellInfo;
    //Event Customization
    private void GridControl_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
    {
        if(e.RowIndex==2 && e.ColIndex==2)
        {
            e.Style.CellType = GridCellTypeName.CheckBox;
            e.Style.Description = "CheckBox";
            e.Style.CheckBoxOptions.CheckedValue = "True";
            e.Style.CellValue="True";
        }
    }
