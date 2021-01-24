    private void FilterTxtbox_TextChanged(object sender, EventArgs e)
	{
        string allColumns = "WiuAddressCol + SubDivLongNameCol + StationNameCol + LineSegCol + MilepostCol + MilepostSuffixCol";
		if (uxFilterTxtbox.Text != "Type Here...")
		{
			string[] split = uxFilterTxtbox.Text.Split(',');
			var mainSearchString = allColumns + " LIKE '%"+ split[0]?.Trim( )+ "%'";
			if (split.Length > 1)
			{
				for (int i = 1; i < split.Length; i++)
				{
					mainSearchString += " OR "+ allColumns + " LIKE '%" + split[i]?.Trim() + "%'";
				}
				(uxWiuInfoGrid.DataSource as DataTable).DefaultView.RowFilter = mainSearchString;
			}
			else
			{
				(uxWiuInfoGrid.DataSource as DataTable).DefaultView.RowFilter = mainSearchString;
			}
		}
	}
