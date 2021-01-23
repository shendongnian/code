	private void AddNewColumns()
    {
		metroGrid2.Columns.Add("newColumnName", "Column Name in Text");
		//To add values to the column you should run a foreach loop 
		foreach (DataGridViewRow row in metroGrid2.Rows) 
		{
			if (row.Cells[1].Value.ToString()=="1") //Some condition or value  
				row.Cells[2].Value = "50%"; 
		}
    }
	
