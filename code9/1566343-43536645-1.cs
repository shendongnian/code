    //get grid as Item's parent
    DataGrid grid = e.Item.Parent.NamingContainer as DataGrid
    //alternatively, you can search for grid in DataList controls, like this:
    // yourList.FindControl("dgWarrant1") as DataGrid;
    // if INCOME_TREATMENT <> R
    if (e.Item.Cells[5].Text != "R")
    {
    	grid.Columns[4].HeaderText = "DISTRIBUTION DATE";
    }
    else
    {
    	grid.Columns[4].HeaderText = "REINVESTMENT DATE";
    }
