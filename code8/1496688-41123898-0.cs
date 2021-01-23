    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //loop all cells in the row
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                //set the tooltip text to be the header text
                e.Row.Cells[i].ToolTip = GridView1.HeaderRow.Cells[i].Text;
            }
        }
    }
