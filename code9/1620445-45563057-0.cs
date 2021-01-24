    if (ds.Tables["logtbl"].Rows.Count > 0)
    {
        GridView1.DataSourceID = null; // string.Empty can also used
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
