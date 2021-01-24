	for(int r=0; r<matematicaDataGridView.Rows.Count; r++)
	{
		object value1 = matematicaDataGridView[1, r].Value;
		object value2 = matematicaDataGridView[2, r].Value;
		int val1, val2;
		if (int.TryParse((string)value1, out val1) && int.TryParse((string)value2, out val2))
		{
			matematicaDataGridView[3, r].Value = val1 - val2;
		}
		else
		{
			//MessageBox.Show(" invalid inputs.");
		}
	}
