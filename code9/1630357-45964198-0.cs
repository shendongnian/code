    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get comany name id from gridview and cast to Label and get its value
            string companyName = (e.Row.Cells[0].FindControl("CompanyName") as Label).Text;
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
