	int maxRows = usedRange.Rows.Count;
	for (int i=1;i<=maxRows;i++)
	{
		// Column 1 is customer number
	   // THE FOLLOWING LINE RETURNS NULL STARTING AT ROW 144
	   cellValue = xlWorkSheet.Cells[i, 1].Value2 == null ? "" : xlWorkSheet.Cells[i, 1].Value2.ToString();
		
		if (!(cellValue.Length >= 5 && cellValue.Length <= 20))
		{
			MessageBox.Show(cellValue + " Must be between 5 and 20 Characters - File Will Not Be Processed Row#" + i.ToString());
			runProcess = false;
		}
	}
