     protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
      {
	   if (e.Row.RowType == DataControlRowType.DataRow) {
	     CheckBox chk = (row.Cells[0].FindControl("chkid") as CheckBox);
            if (chk.Checked)
            {
             
		     //Create the hiddenfield or viewstate which you can access page level.
            }
     	 }
     }
