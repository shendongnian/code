    dgvAssets.DataSource = rowData.asset_table;
	int[] colsDate = dataGridView1.Columns
				                  .Cast<DataGridViewColumn>()
				                  .Where(col => col.Name.Contains("DATA"))
			                 	  .Select(col => col.Index)
			                      .ToArray();
	dataGridView1.CellFormatting += (s, e) =>
	{
		if (colsDate.Contains(e.ColumnIndex))
		{
			var date = DateTime.ParseExact(e.Value.ToString(), "yyyyMMddhhmmss", CultureInfo.InvariantCulture);
			e.Value = date.ToString("dd/MM/yyyy HH:mm:ss tt");
			e.FormattingApplied = true;
		}
	};
