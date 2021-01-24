    string previousCellValue = "";
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the dataitem back to a row
            DataRowView row = e.Row.DataItem as DataRowView;
            //check if the current id matches the previous row
            if (previousCellValue == row["Id"].ToString())
            {
                //clear the first cell
                e.Row.Cells[0].Text = "";
                //apply column span
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[1].Visible = false;
            }
            else
            {
                previousCellValue = row["Id"].ToString();
            }
        }
    }
