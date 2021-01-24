    DataTable table = new DataTable();
    //test data
    table.Columns.Add("Name");
    table.Columns.Add("X", typeof(int));
    table.Rows.Add(new object[] { "john", 10 });
    table.Rows.Add(new object[] { "paul", 44 });
    table.Rows.Add(new object[] { "ringo", 312 });
    table.Rows.Add(new object[] { "george", 30 });
    table.Rows.Add(new object[] { "john", 100 });
    table.Rows.Add(new object[] { "paul", 443 });
    
    //converting DataTable to enumerable collection of rows and then grouping by name, 
    //skipping groups with only one row(such as george or ringo)
    var groupedData = table.AsEnumerable().GroupBy(row => row[0].ToString()).Where(g => g.Count() > 1);
    
    //iterate through each group of <string, DataRow>
    foreach (var group in groupedData)
    {
    	int counter = 1; //counter for "[x]" suffix
    	//iterate through all rows under one name, eg. John
    	foreach (var groupedItem in group)
    	{
    	    //add [x] 
    		groupedItem[0] = string.Format("{0} [{1}]", group.Key, counter);
    		counter++;
    	}
    }
