    // if INCOME_TREATMENT <> R
    if (e.Item.Cells[5].Text != "R")
    {
    	dgWarrant1.Columns[4].HeaderText = "DISTRIBUTION DATE";
    }
    else
    {
    	dgWarrant1.Columns[4].HeaderText = "REINVESTMENT DATE";
    }
