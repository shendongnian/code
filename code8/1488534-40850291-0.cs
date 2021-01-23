    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton test = (ImageButton)e.Row.FindControl("ImageButtonUpdate");
            test.Visible = false;
        }
    }
