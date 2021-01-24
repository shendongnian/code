    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        //cast the dataitem back to a datarowview
        DataRowView drv = e.Row.DataItem as DataRowView;
    
        //loop all the items in the datarowview (not equal to columns in grid)
        for (int i = 0; i < drv.Row.ItemArray.Length; i++)
        {
            //check if it is an uneven column
            if (i % 2 == 0)
            {
                e.Row.Cells[i / 2].Text = drv[i].ToString();
            }
            else
            {
                e.Row.Cells[i / 2].BackColor = Color.FromName(drv[i].ToString());
            }
        }
    }
