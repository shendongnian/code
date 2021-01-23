    DataSet ds = new DataSet();
    ds.ReadXml("xmlfile2.xml");
    foreach(DataTable dt in ds.Tables)
    {
    	Console.WriteLine($"Table Name - {dt.TableName}\n");
    	foreach(DataColumn dc in dt.Columns)
    	{
    		Console.Write($"{dc.ColumnName.PadRight(20)}");
    	}
    	Console.WriteLine();
    	foreach(DataRow dr in dt.Rows)
    	{
    		
    		foreach(object obj in dr.ItemArray)
    		{
    			Console.Write($"{obj.ToString().PadRight(20)}");
    		}
    		Console.WriteLine();
    	}
    	Console.WriteLine(new string('_', 75));
    }
