    // read the files and put the content in a Datatable
    public static DataTable DataTableFromAllTextFiles(string[] files)
    {
       DataTable result = null;
    
       foreach(var file in files) {
    	    //  read one file 
    		var LineArray = File.ReadAllLines(file);
    		// on the first one ...
    		if (result == null) 
    		{
    			// ... create columns
    			result = new DataTable();
    			AddColumnToTable(LineArray, ref result);
    		}
    		// add the rows
    		AddRowToTable(LineArray, ref result);
        }
    	
       return result;
    }
