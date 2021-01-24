	int staffId = Convert.ToInt32(ddlAssign.SelectedValue);
	var staff = BLL.FindStaffByID(staffId);
	var alert = false;
	
	var deadline = DateTime.Today;
	var day = DateTime.Now.DayOfWeek;
	if (!string.IsNullOrEmpty(txtDeadline.Text))
	    deadline = Convert.ToDateTime(txtDeadline.Text);
	
	if (day != DayOfWeek.Saturday && day != DayOfWeek.Sunday)
	{		
		var bin = new ScheduleBin();
		bin.PackBins(staffId);
		
		if (bin.PercentBusy(1) >= 100)
		{
		    if (deadline == DateTime.Today || deadline == DateTime.Today.AddDays(1))
		    {
		        alert = true;
		    }
		}
		
		if (bin.PercentBusy(3) >= 100)
		{
		    if (deadline == DateTime.Today.AddDays(3))
		    {
		        alert = true;
		    }
		}
		
		
		if (bin.PercentBusy(5) >= 100)
		{
		    if (deadline == DateTime.Today || deadline == DateTime.Today.AddDays(7))
		    {
				alert = true;
		    }
		}
		
		if (alert)
		{
		    ScriptManager.RegisterStartupScript(this, GetType(), "script", "<script language='javascript' type='text/javascript'>alert(\"Whoa there! Looks like " + staff.FirstName + " is a bit booked for that deadline (" + d1 + "% | " + d3 + "% | " + d5 + "%). Check out their task list and talk to the AE's to see about clearing out some room, or consider assigning the task to someone else. \");</script>", false);
		} 
	}
