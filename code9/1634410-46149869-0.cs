    //Event Triggering
    this.gridDataBoundGrid1.CellClick += GridDataBoundGrid1_CellClick;
    
    //Event handling
    private void GridDataBoundGrid1_CellClick(object sender, GridCellClickEventArgs e)
    {
        //To Check for column header cell
        if(this.gridDataBoundGrid1[e.RowIndex, e.ColIndex].CellType == "ColumnHeaderCell")
    {
    //Your code show the another part of the project.
    }
    }
