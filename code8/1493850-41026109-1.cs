    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find the button in the row with findcontrol and cast back to a button
            Button button = e.Row.FindControl("btnstatus") as Button;
    
            //check dt1 and set button text
            button.Text = "Active";
        }
    }
