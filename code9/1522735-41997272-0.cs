    int counter = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            counter = 0;
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            counter++;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label1.Text = counter + " rows in GridView";
        }
    }
