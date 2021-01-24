    void Main()
    {
    	var dt = CSVtoDataTable(@"c:\temp\test.csv");
    
    	foreach (DataRow row in dt.Rows)
    	foreach (DataColumn col in dt.Columns)
    	{
    		var str = row[col].ToString();
    		row[col] = RegexReplace(str);
    	}
    
    	string json = JsonConvert.SerializeObject(dt);
    }
    
    public DataTable CSVtoDataTable(string filepath)
    {
    	DataSet ds = new DataSet("Temp");
    
    	using (OleDbConnection conn = new OleDbConnection($"Provider=Microsoft.Jet.OleDb.4.0; Data Source = {Path.GetDirectoryName(filepath)}; Extended Properties = \"Text;HDR=YES;FMT=Delimited\""))
    	{
    		conn.Open();
    		OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(filepath), conn);
    		adapter.Fill(ds);
    	}
    	return ds.Tables[0];
    
    }
    
    public string RegexReplace(string s)
    {
    	return Regex.Replace(s, @"\b[a-z]\w+", "*****");
    }
