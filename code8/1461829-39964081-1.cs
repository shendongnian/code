    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var status = (Button) e.Row.FindControl("out");
            status.Visible = e.Row.Cells.Cast<TableCell>()
                .All(cell => !string.IsNullOrEmpty(cell.Text));
        }
    }
