    foreach (DataGridViewRow row in this.dgvMain.Rows)
	{
		if (row.DefaultCellStyle.BackColor == Color.Green)
		{
			object[] rowData = new object[row.Cells.Count];
			for (int i = 0; i < rowData.Length; ++i)
			{
				rowData[i] = row.Cells[i].Value;
			}
			ApprovedDTable.Rows.Add(rowData);
		}
	}
