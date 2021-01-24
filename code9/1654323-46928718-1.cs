    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the dataitem back to a row
            DataRowView row = e.Row.DataItem as DataRowView;
            //find the edit button in the row with findcontrol
            LinkButton btn = e.Row.FindControl("EditButtonID") as LinkButton;
            //check the status of the correct data field and set the button properties
            if (row["statuse"].ToString() == "Closed")
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }
    }
