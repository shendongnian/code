    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find your label control in gridview
            Label lb = (Label)e.Row.FindControl("Label_SelectedCount");
            string count = lb.Text;
        }
    }
