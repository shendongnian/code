    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //loop all columns in the row
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                //check if the string is null of empty in the source data
                //(row[i]) instead of e.Row.Cells[i].Text
                if (string.IsNullOrEmpty(row[i].ToString()))
                {
                    e.Row.Cells[i].BackColor = Color.Green;
                }
                else
                {
                    e.Row.Cells[i].BackColor = Color.White;
                }
            }
        }
    }
