    protected void AllUsersGridView_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    
    		LinkButton LinkButton1 = (LinkButton)e.Row.Cells[6].FindControl("LinkButton1");
    		LinkButton LinkButton2 = (LinkButton)e.Row.Cells[6].FindControl("LinkButton2");
    
    		DataRow row = ((DataRowView)e.Row.DataItem).Row;
    		bool isChecked = row.Field<bool>("[FiledName]");
    		// CheckBox c = ((CheckBox)e.Row.Cells[2]);
    		
    		LinkButton1.Visible = isChecked;
    		LinkButton2.Visible = isChecked;
    	}
    }
