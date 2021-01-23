    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool isRowEmpty = true;
            // Check all cells inside this current row.
            foreach (TableCell cell in e.Row.Cells)
            {
                if (!string.IsNullOrEmpty(cell.Text))
                {
                    isRowEmpty = false;
                    break;
                }
            }
    
            if (isRowEmpty)
            {
                var status = (Button) e.Row.FindControl("out");
                status.Visible = false;
            }
        }
    }
