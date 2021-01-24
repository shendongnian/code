    private void button1_Click(object sender, EventArgs e) {   
    	DataTable dt = new DataTable();
    	foreach(DataGridViewColumn col in dataGridView1.Columns)
    	{
    		dt.Columns.Add(col.HeaderText);    
    	}
    
    	foreach(DataGridViewRow row in dataGridView1.Rows)
    	{
    		DataRow newrow = dt.NewRow();
    		foreach(DataGridViewCell cell in row.Cells)
    		{
    			newrow[cell.ColumnIndex] = cell.Value;
    		}
    		dt.Rows.Add(newrow);
    	}
    	dt.DefaultView.RowFilter = $"FName LIKE '%{textBox1.Text}%'";
    }
