    void Main()
    {
    	string vfpInsert = @"Insert Into client 
    	(CLCODE,CLCODEDESC,CLCLASS,FNAME,MNAME,SNAME) 
        SELECT CLCODE,CLCODEDESC,CLCLASS,FNAME,MNAME,SNAME 
    	 from (Iif(Xmltocursor(?,'xlData') > 0, 'xlData','')) xl 
         where Not Exists
    	  (Select * From client c2 Where c2.CLCODE == xl.CLCODE)";
    	
    	var xml = GetExcelData();
    	
    	using (OleDbConnection con=new OleDbConnection(@"provider=VFPOLEDB;Data Source="+@"d:\backyard\temp"))
    	using (OleDbCommand cmd = new OleDbCommand(vfpInsert,con))
    	{
    		cmd.Parameters.Add("xldata", OleDbType.VarChar).Value = xml;
    		con.Open();
    		cmd.ExecuteNonQuery();
    		con.Close();
    	}
    }
    
    private string GetExcelData()
    {
    	string dataSource = @"D:\temp\myclients.xlsx";
    	DataTable t = new DataTable("Clients");
    
    	using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
    	  string.Format("Data Source={0};", dataSource) +
    	  "Extended Properties=\"Excel 12.0;HDR=Yes\""))
    	using (OleDbCommand cmd = new OleDbCommand("Select * from [clients$]", con))
    	{
    		con.Open();
    		t.Load(cmd.ExecuteReader());
    		con.Close();
    	}
    	using (MemoryStream ms = new MemoryStream())
    	using (var xmlwriter = XmlTextWriter.Create(ms))
    	{
    		t.WriteXml(xmlwriter, XmlWriteMode.WriteSchema);
    		xmlwriter.Flush();
    		xmlwriter.Close();
    		ms.Position = 0;
    		using (StreamReader streamreader = new StreamReader(ms))
    		{
    			return streamreader.ReadToEnd();
    		}
    	}
    }
