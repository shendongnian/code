	DataTable dt = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, 
                    new object[] { null,null, sSheetName, null });
	List<string> columnNames = new List<string>();
	foreach (DataRow row in dt.Rows)
		columnNames.Add(row["Column_name"].ToString()); 
