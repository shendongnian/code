	private void GetData()
	{
		int i;
		ArrayList arr;
		if (ViewState["SelectedRecords"] != null)
			arr = (ArrayList)ViewState["SelectedRecords"];
		else
			arr = new ArrayList();
		for (i = 0; i < KeszletGrid.Rows.Count; i++)
		{
			CheckBox chk = null;
			if ((chk = (CheckBox)KeszletGrid).Rows[i].Cells[0].FindControl("chk"))
			{
				if (chk.Checked)
				{
					if (!arr.Contains(KeszletGrid.DataKeys[i].Value))
					{
						arr.Add(KeszletGrid.DataKeys[i].Value);
					}
				}
				else
				{
					if (arr.Contains(KeszletGrid.DataKeys[i].Value))
					{
						arr.Remove(KeszletGrid.DataKeys[i].Value);
					}
				}
			}
		}
	}
