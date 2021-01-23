    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find the nested grid in the current row with findcontrol
            GridView gridView = e.Row.FindControl("nestedGridView") as GridView;
    
            //check if it is the first nested gridview and show/hide the header
            if (e.Row.RowIndex == 0)
            {
                gridView.ShowHeader = true;
            }
            else
            {
                gridView.ShowHeader = false;
            }
    
            //fill the nested grid with data
            gridView.DataSource = dataSource;
            gridView.DataBind();
        }
    }
