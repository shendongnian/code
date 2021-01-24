    if (e.RowIndex >= 0)
    {
    	if (e.ColumnIndex == 8 || e.ColumnIndex == 10 || e.ColumnIndex == 14)
    	{
    		DataGridViewRow row = this.Dgv_View_Employees.Rows[e.RowIndex];
    		string filenametodisplay = row.Cells[e.ColumnIndex].Value.ToString();
    		string targetPath = @"C:\root";
    		string open = System.IO.Path.Combine(targetPath + filenametodisplay);
    		System.Diagnostics.Process.Start(open);
    	}
    }
