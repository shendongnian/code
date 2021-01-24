    protected void GridViewClicks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the current row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //loop all the cells in the row
            foreach (TableCell cell in e.Row.Cells)
            {
                //check if the color is hex or a string
                if (cell.Text.Contains("#"))
                {
                    cell.BackColor = ColorTranslator.FromHtml(cell.Text);
                }
                else
                {
                    cell.BackColor = Color.FromName(cell.Text);
                }
            }
        }
    }
