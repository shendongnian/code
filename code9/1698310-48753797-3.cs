    private void DataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
	{
		foreach(DataGridViewColumn item in dataGridView1.Columns)
		{
			if(e.Column.HeaderText == item.HeaderText)
			{
				dataGridView1.Columns.Remove(e.Column);
			}
		}
	}
