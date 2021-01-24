	private void gridVerknuepfteMaterialien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (!(e.RowIndex >= 0 && e.ColumnIndex >= 0)) return;
		DataGridViewCell cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
		
		if (!(cell is DataGridViewCheckBoxCell)) return;
		cell.ReadOnly = !System.Convert.ToBoolean(cell.Value);
	}
