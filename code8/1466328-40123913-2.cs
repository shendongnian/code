	if (grdView.Rows.Count > 0)
	{
		var states = new List<string>();
		foreach (GridViewRow row in grdView.Rows)
		{
			var chkbox = row.FindControl("chkbox") as CheckBox;
			if (chkbox.Checked)
			{
			    var lblJurisdiction = row.FindControl("lblJurisdiction") as Label;
				states.Add(lblJurisdiction.Text);
			}
		}
		hdnJurisdiction.Value = string.Join(", ", states.Distinct().OrderBy(x => x));
	}
