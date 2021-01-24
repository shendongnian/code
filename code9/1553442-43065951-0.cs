	using System.Data.OleDb;
	foreach (var item in paths)
	{
		string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + item + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
		 using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
		{
			excelConnection.Open();
			DataTable dt = new DataTable(); //excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
			string query = sheetname.Contains(" ") ? string.Format("Select * from ['{0}$']", sheetname) : string.Format("Select * from [{0}$]", sheetname);
			using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection))
			{
				dataAdapter.Fill(dt);
			}
		
			//do something with the data here
			
			excelConnection.Close();
		}
	}
