    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if its not a header or footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get value from first cell of gridview
            string companyName = e.Row.Cells[0].Text;
            switch (companyName)
            {
                case "Company 1":
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                    break;
                case "Company 2":
                    e.Row.BackColor = System.Drawing.Color.White;
                    break;
                case "Company 3":
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                    break;
                default:
                    break;
            }
        }
    }
