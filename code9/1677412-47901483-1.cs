    protected void update_url(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        var row = (DataRowView)e.Row.DataItem;
        var id = (int)row["ID"];
        // ...
      }
    }
