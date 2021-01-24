    DataTable dt = new DataTable();
    	DropDownList drp = new DropDownList();
    
    	dt.Columns.Add("Name", typeof(string));
    	dt.Columns.Add("Employer", typeof(DropDownList));
    
    	drp.Items.Add(new ListItem("test", "0"));
    
    	foreach (SPListItem item in queryResults)
    	{
    
    	  dr["Name"] = item["iv3h"].ToString();
    	  //dr["Employer"] = drp; --object being added when you need the control.
    	  dt.Rows.Add(dr);
    	}
    
    	BoundField bf = new BoundField();
    	bf.DataField = "Name";
    	bf.HeaderText = "Name";
    	bf.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
    	bf.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
    	GridViewEarningLine.Columns.Add(bf);
    
    //Here is how you can add the control with the contents as needed.
    	foreach (GridViewRow row in GridViewEarningLine.Rows)
    	{
    		drp = new DropDownList();
    		drp.DataSource = list;
    		drp.DataBind();
    		drp.SelectedIndex = -1;
    		row.Cells[1].Controls.Add(drp);
    	}
