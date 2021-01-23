    void Main()
    {
        //sample data for test 
    	DataSet ds = new DataSet();
    	ds.Tables.Add(GetTable1());
    	ds.Tables.Add(GetTable2());
    	
    	var result  = ( from rec1 in ds.Tables[0].AsEnumerable()
    	join rec2  in ds.Tables[1].AsEnumerable()
    	 on   rec1.Field<string>("FC") equals rec2.Field<string>("FC")
    	 where rec2.Field<int>("Value") == 2  select rec1);
    	 
    	 result.ToList().ForEach(row => row.Delete());
    	 //now you have only "ABCD" and "AZY" in table 1
    	 //ds.Tables[0].Dump(); linqpad display result
    }
    
    DataTable GetTable1()
    {
    	DataTable table = new DataTable();
    	table.Columns.Add("FC", typeof(string));
    	table.Rows.Add("ABCD");
    	table.Rows.Add("XYZ");
    	table.Rows.Add("AZY");
    	return table;
    }
    
     DataTable GetTable2()
    {
    	DataTable table = new DataTable();
    	table.Columns.Add("FC", typeof(string));
    		table.Columns.Add("Value", typeof(int));
    	table.Rows.Add("ABCD", 1);
    	table.Rows.Add("XYZ", 2);
    	table.Rows.Add("AZY",3);
    	return table;
    }
