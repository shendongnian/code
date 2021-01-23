    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        BindingSource bnd = (BindingSource)grid1.DataSource;
        DataTable dt = (DataTable)bnd.DataSource;
        if(dt != null)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = "col1 desc";
            DataTable sortedDT = dv.ToTable();
            grid1.DataSource = dortedDT;
        }
    }
