    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the dataitem back to a row
            DataRowView row = e.Row.DataItem as DataRowView;
            e.Row.Attributes.Add("extravalue", row["Column 4"].ToString());
        }
    }
