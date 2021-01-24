    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find your label text in gridview with DataBinder.Eval
            string count = DataBinder.Eval(e.Row.DataItem, "Count") as string;
            // find your label control in gridview
            Label lb = (Label)e.Row.FindControl("Label_SelectedCount");
            // check condition to show/hide label (you use your own condition)
            if(count > 0)
                lb.Visible = true;
            else
                lb.Visible = false;
        }
    }
