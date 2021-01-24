    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
    {
    	foreach (DataGridViewColumn column in dataGridView1.Columns)
    	{
    		if (!column.Visible || column.DisplayIndex < 0)
                continue;
    		value = dataGridView1.Rows[i].Cells[column.DisplayIndex].Value.ToString();
    		if (value.Contains(str) == false)
    		{
    			dataGridView1.Rows.RemoveAt(i);
    		}
    	}
    }
