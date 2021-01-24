    using (var rdr = ExcelReaderFactory.CreateOpenXmlReader(fs))
	{
		var conf=new ExcelDataSetConfiguration()
		{
			ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
			{
				UseHeaderRow = true //THIS IS WHAT YOU ARE AFTER
			}
		};
		var ds = rdr.AsDataSet(conf); //THIS IS WHERE IT IS USED
	}
