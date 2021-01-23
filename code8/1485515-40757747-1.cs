	foreach (GridViewRow gvRow in gvProxyEntry.Rows)
	{
		List<object> emptyControls = new List<object>();
		foreach (TableCell cell in gvRow.Cells)
		{
            foreach(Control c in cell.Controls)//newly added foreach loop
            {
			    Type controlType = c.GetType();
			    if (controlType == typeof(CheckBox))
			    {
				    CheckBox chkBox = (CheckBox)c;
				    if (chkBox.Checked == false)
				    {
					    emptyControls.Add(chkBox);
				    }
			    }
                ...
            }
           ... 
		}
       ...
    }
