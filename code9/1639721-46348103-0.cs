    protected void Page_Load(object sender, EventArgs e)
    {
            // Force the gridview into edit mode always becuase its formatting looks a million times better
            GridView1.EditIndex = 0;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            // Default to edit mode
            if (GridView1.EditIndex == -1)
                GridView1.EditIndex = 0;
    }
