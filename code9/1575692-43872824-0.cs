    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the dataitem back to a datarowview 
            DataRowView row = e.Row.DataItem as DataRowView;
            //find the column value in the row, not the cell text
            string test = row["columnName"].ToString();
            //check the value and if so apply backcolor
            if (test == "Y")
            {
                e.Row.BackColor = Color.Red;
                //or hide the row (no need to do this in Databind or OnPreRender)
                e.Row.Visible = false;
            }
        }
    }
