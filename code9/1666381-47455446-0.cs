    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
       
        DataTable dt = GetDataDataTableGeneric();
        dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
    
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
