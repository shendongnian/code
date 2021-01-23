	public byte[] TestExcellGeneration_HorizontalLoadFromCollection()
	{
		byte[] result = null;
		using (ExcelPackage pck = new ExcelPackage())
		{
			var foo = pck.Workbook.Worksheets.Add("Foo");
			var randomData = new[] { "Foo", "Bar", "Baz" }.ToList();
			//foo.Cells["B4"].LoadFromCollection(randomData);
			int startColumn = 2; // "B";
			int startRow = 4;
			for(int i = 0; i < randomData.Count; i++)
			{
				foo.Cells[startRow, startColumn + i].Value = randomData[i];
			}
			result = pck.GetAsByteArray();
		}            
		return result;
	}
