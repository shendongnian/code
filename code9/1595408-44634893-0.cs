    private void FilterTxtbox_TextChanged(object sender, EventArgs e)
	{
		if (uxFilterTxtbox.Text != "Type Here...")
		{
			string[] split = uxFilterTxtbox.Text.Split(',');
			var mainSearchString = "WiuAddressCol + SubDivLongNameCol + StationNameCol + LineSegCol + MilepostCol + MilepostSuffixCol LIKE '%"+ split[0]?.Trim( )+ "%'";
			if (split.Length > 1)
			{
				for (int i = 1; i < split.Length; i++)
				{
					mainSearchString += " OR WiuAddressCol + SubDivLongNameCol + StationNameCol + LineSegCol + MilepostCol + MilepostSuffixCol LIKE '%" + split[i]?.Trim() + "%'";
				}
				(uxWiuInfoGrid.DataSource as DataTable).DefaultView.RowFilter = mainSearchString;
			}
			else
			{
				(uxWiuInfoGrid.DataSource as DataTable).DefaultView.RowFilter = mainSearchString;
			}
		}
	}
