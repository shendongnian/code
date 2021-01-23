	if (grdView.Rows.Count > 0)
	{
		var items = new List<string>();
		foreach (GridViewRow row in grdView.Rows)
		{
			var chkbox = row.FindControl("chkbox") as CheckBox;
			if (chkbox.Checked)
			{
			    var lblJurisdiction = row.FindControl("lblJurisdiction") as Label;
				items.Add(lblJurisdiction.Text);
			}
		}
		var unique = items.Distinct().OrderBy(x => x);
		hdnJurisdiction.Value = string.Join(", ", unique);
	}
