    foreach (DataTable table in result.Tables)
    {
    	foreach (DataRow row in table.Rows)
    	{
    		var salesRepName = (string)row["Sales_Rep_Name"];
    		if (String.Equals(salesRepName, "Janet"))
    		{
    			var year = (int)(double)row["Year"];
    			Console.WriteLine($"Janet's year is {year}");
    		}
    	}
    }
