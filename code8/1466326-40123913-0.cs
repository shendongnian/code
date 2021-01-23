	if (grdView.Rows.Count > 0)
	{
		var items = new List<String>();
		foreach (GridViewRow row in grdView.Rows)
		{
			var chkbox = row.FindControl("chkbox") as CheckBox;
			if (chkbox.Checked)
			{
			    var lblJurisdiction = row.FindControl("lblJurisdiction") as Label;
				items.Add(lblJurisdiction.Text);
			}
		}
		var unique = items.Distinct().OrderBy(x=>x).ToList();
		var replacedJurisdiction = string.Join(", ", unique);
		hdnJurisdiction.Value = replacedJurisdiction;
	}
