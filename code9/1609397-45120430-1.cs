	public Excel(string path, int Sheet)
	{
		excel.Visible = false;
		wb = excel.Workbooks.Add();
		ws = (Worksheet)wb.Worksheets[1];
        if (ws == null)
        {
            Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
        }
	}
