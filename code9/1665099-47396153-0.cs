    Func<string, DataGridViewRow> getRow = (menuCode) =>
	{
		return menuDataGrid.Rows.Cast<DataGridViewRow>()
			.First(r => ((string)r.Cells[3].Value).Equals(menuCode));
	};
	var selected = menuListBox.SelectedItem.ToString();
	pricetxtbox.Text = getRow(selected).Cells[5].Value.ToString();
	totaltxtbox.Text = menuListBox.Items.Cast<object>()
		.Select(o => o.ToString())
		.Select(i => (int)getRow(i).Cells[5].Value)
		.Sum()
		.ToString();
