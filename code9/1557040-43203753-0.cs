    private IEnumerable<string> GetTablesFromExcel(string dataSource)
    {
    	IEnumerable<string> tables;
    	using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
    	string.Format("Data Source={0};", dataSource) +
    	"Extended Properties=\"Excel 12.0;HDR=Yes\""))
    	{
    		con.Open();
    		var schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    		tables = schemaTable.AsEnumerable().Select(t => t.Field<string>("TABLE_NAME")); 
    		con.Close();
    	}
    	return tables;
    }
