    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string lblSqlValue = ((Label)e.Row.FindControl("lblSqlValue")).Text;
            Label lblAlias = e.Row.FindControl("lblAlias") as Label;
            if (lblSqlValue=="order not placed")
                lblAlias.Text = "Awaiting confirmation";
            else if(lblSqlValue=="Emailed")
                lblAlias.Text = "order confirmed for collection";
            else
                lblAlias.Text = "No Value";
        }
    }
