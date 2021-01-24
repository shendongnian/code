    protected void bedStats_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                //do stuff with the first row
            }
            if (e.Row.RowIndex % 2 == 0)
            {
                //if you want to do something to rows 1, 3, 5 etc
            }
        }
    }
