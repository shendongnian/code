    protected void XDataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //loop all the cells in the row
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = "<div>" + e.Row.Cells[i].Text + "</div>";
            }
        }
    }
