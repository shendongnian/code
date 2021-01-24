    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LikeButton LB = e.Row.FindControl("CandidateLikeButton") as LikeButton;
            LB.CandidateID = 1234;
        }
    }
