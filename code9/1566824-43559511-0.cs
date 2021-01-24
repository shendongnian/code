	string strExcelConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\filename.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'";
	using (OleDbConnection connExcel = new OleDbConnection(strExcelConn))
	{
	    string selectString = "SELECT * FROM [CA$A1:D500]";
	    using (OleDbCommand cmdExcel = new OleDbCommand(selectString,connExcel))
	    {
	        cmdExcel.Connection = connExcel;
	        connExcel.Open();
	        DataTable dt=new DataTable();                    
	        OleDbDataAdapter adp = new OleDbDataAdapter();
	        adp.SelectCommand = cmdExcel;
	        adp.FillSchema(dt, SchemaType.Source);
	        adp.Fill(dt);
	        int range=dt.Columns.Count;
	        int row = dt.Rows.Count;
		}
	}
