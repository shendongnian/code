	public static void ImportData(string targetPathwithName, System.Data.DataTable dt1, string targetName)
	{
		var con = ConfigurationManager.ConnectionStrings["con1"].ConnectionString.ToString();
		var connection = new SqlConnection(con);
		connection.Open();
		var bulkCopy = new SqlBulkCopy(connection);
		foreach (System.Data.DataTable dt in GetFileData(targetPathwithName, dt1))
		{
			bulkCopy.DestinationTableName = "[" + targetName + "]";
			bulkCopy.WriteToServer(dt);
		}
		bulkCopy.Close();
		connection.Close();
	}
	public static IEnumerable<System.Data.DataTable> GetFileData(string sourceFileFullName, System.Data.DataTable dt1)
	{
		var con = ConfigurationManager.ConnectionStrings["con1"].ConnectionString.ToString();
		var connection = new SqlConnection(con);
		int chunkRowCount = 0;
		//int RowCount = 0;
		string Row;
		using (var sr = new StreamReader(sourceFileFullName))
		{
			//if (RowCount != 0) { //this is not meaningful here
			
			//Read and display lines from the file until the end of the file is reached.                
			while ((Row = sr.ReadLine()) != null)
			{
				chunkRowCount++;
				//var chunkDataTable = ; //Code for filling datatable or whatever  
				dt1.Rows.Add();
				int i = 0;
				foreach (string Cell in Row.Split(','))
				{
					if (String.IsNullOrEmpty(Cell))
					{
						dt1.Rows[dt1.Rows.Count - 1][i] = DBNull.Value;
						i = i + 1;
					}
					else if (Cell == "00.00.0000")
					{
						dt1.Rows[dt1.Rows.Count - 1][i] = DBNull.Value;
						i = i + 1;
					}
					else
					{
						dt1.Rows[dt1.Rows.Count - 1][i] = Cell;
						i = i + 1;
					}
				}
				if (chunkRowCount == 10000)
				{
					chunkRowCount = 0;
					yield return dt1;
					dt1.Clear(); // = null;
				}
			} //end while
			//}
			//RowCount = RowCount + 1;
		}
		//return last set of data which less then chunk size
		if (dt1.Rows.Count > 0)
			yield return dt1;
	}
