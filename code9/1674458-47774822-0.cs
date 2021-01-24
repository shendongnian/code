    protected void soGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var idNumLink = (HyperLink) e.Row.Cells[2].Controls[0];
            string idNum= idNumLink.Text;
        }
    }
