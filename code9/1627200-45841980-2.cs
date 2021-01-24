    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check gridview row is not in edit mode
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            // get correct Label value
            string value = (e.Row.FindControl("lblStatusv") as Label).Text; 
            // convert string value into an integer value
            int intValue = int.Parse(value);
            if (intValue == 1)
            {
                e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
            }
        }
    }
