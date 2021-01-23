    protected void OnRowDataBound123(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string cellValue = statusCell1 = e.Row.Cells[1].Text;
            if (cellValue != "-")
            {
                string[] a = cellValue.Split('/');
                if (a[0] != a[1])
                {
                    statusCell1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
