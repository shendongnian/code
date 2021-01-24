    //Event Triggering
    this.gridControl1.QueryCellInfo += GridControl_QueryCellInfo;
    //Event Customization
    private void GridControl_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
    {
        if(e.RowIndex==1 && e.ColIndex==1)
        {
            e.Style.CellValue = "Sample Name";
        }
        if(e.RowIndex==2 && e.ColIndex==1)
        {
            e.Style.Text = "Sample ID";
        }
    }
