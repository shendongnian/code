    protected void dgrMainGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataTable dt = Session["Grid"] as DataTable;
    
        if (dt != null)
        {
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            dgrMainGrid.DataSource = dt;
            dgrMainGrid.DataBind();
        }
    }
