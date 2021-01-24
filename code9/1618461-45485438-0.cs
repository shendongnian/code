    protected void gvcmi_DataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			Label LastVisitLbl = (Label)e.Row.Cells[7].FindControl("lblStatusv");
    			If (DateTime.ParseExact(LastVisitLbl.Text, "dd/MM/yyyy", Thread.CurrentThread.CurrentUICulture.DateTimeFormat) >= DateTime.Today.AddMonths(-3)
    			{
    				//Do Something
    			}
    		}
    }
