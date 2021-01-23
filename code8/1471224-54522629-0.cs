    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            var d = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (d != null) lblGridRowsCount.Text = d.Count.ToString();
    }
