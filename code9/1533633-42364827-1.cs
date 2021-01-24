    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow tr = e.Row;
            tr.Attributes.Add("onClick", "javascript:selectMe(this);");
            tr.Attributes.Add("style", "cursor:hand;");
        }
    }
