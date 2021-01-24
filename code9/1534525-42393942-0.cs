    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string myClass = string.Empty;
            //check if the row is alternate, if so set the alternating class
            if (e.Row.RowIndex % 2 == 1)
            {
                myClass = "gvAlternatingStyle";
            }
            //check if you need to add the extra class
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            if (!row.Field<Boolean>("IsActive"))
            {
                myClass += " Inactive";
            }
            //add all the classes to the row
            e.Row.Attributes["class"] = myClass.Trim();
        }
    }
