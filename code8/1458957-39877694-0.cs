        protected void Mastergrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "exportNestedGrid")
            {
                //convert the CommandArgument
                int rowNumber = Convert.ToInt32(e.CommandArgument);
                //find the nested GridView
                GridView gridview = GridView1.Rows[rowNumber].FindControl("subgrid") as GridView;
                //do stuff with the nested GridView
                gridview.Visible = false;
            }
        }
