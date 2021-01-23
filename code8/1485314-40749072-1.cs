    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["griddatasource"] as DataTable;
        if(dt != null)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = "col1 desc";
            DataTable sortedDT = dv.ToTable();
            grid1.DataSource = dortedDT;
        }
    }
