    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var status = (Button) e.Row.FindControl("out");
            // Show button if at least one cell is empty.
            status.Visible = e.Row.Cells.Cast<TableCell>()
                .Any(cell => string.IsNullOrEmpty(cell.Text));
        }
    }
