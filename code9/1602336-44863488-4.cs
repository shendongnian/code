    List<string> tblNames = new List<string>();
    OpenFileDialog ofd = new OpenFileDialog();
    
    if (ofd.ShowDialog() ?? false)
    {
    	using (FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    	{
    		using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
    		{
    			var result = reader.AsDataSet(new ExcelDataSetConfiguration()
    			{
    				UseColumnDataType = true,
    										 
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {                                
                        UseHeaderRow = true
                    }
    			});
    
    			foreach (DataTable dt in result.Tables)
    				tblNames.Add(dt.TableName);
    		}
    	}
    }
