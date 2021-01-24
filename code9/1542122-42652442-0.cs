    protected void gvProposals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
            {
              (e.Row.FindControl("lblCount") as Label).Text = counter.ToString();
        }
    }
