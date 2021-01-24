    void Main()
    {
    	string strCon =
    		   @"Provider=vfpoledb;Data Source=C:\PROGRAM FILES (x86)\MICROSOFT VISUAL FOXPRO 9\SAMPLES\data\testdata.dbc";
    	DataTable tableInfo;
    	using (OleDbConnection con = new OleDbConnection(strCon))
    	{
    		con.Open();
    		tableInfo = con.GetSchema("Tables");
    		
    		// or get TABLES only
    		// tableInfo = con.GetSchema("Tables", new string[] {null,null,null,"TABLE"});
    		
    		con.Close();
    	}
    	foreach (DataRow row in tableInfo.Rows)
    	{
    		Console.WriteLine(@"Name:[{0}] Type:[{1}]",
    			row["TABLE_NAME"],
    			row["TABLE_TYPE"]);
    	}
    }
