    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //find the button with findcontrol
            Button btn = e.Row.FindControl("btnGenNew") as Button;
            //use the paystatus of the current row to enable the button
            if (row["PayStatus"].ToString() == "Approved")
            {
                btn.Enabled = true;
            }
        }
    }
