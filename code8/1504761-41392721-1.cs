    protected void GridDataBound(object sender, EventArgs e)
    {
        GridView gridView = (GridView)sender;
        DataTable dt= (DataTable)gridView .DataSource;
        decimal sum= dt.AsEnumerable().Sum(r => r.Field<decimal>("Amount"));
        totalLabel.Text = sum.ToString();
    }
