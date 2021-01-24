	const string oQuery = "SELECT UPRN, RefuseDay, RefuseWeek FROM RefuseDay";
	const string sqlQuery = "INSERT INTO Ref_RefuseDay (UPRN, RefuseDay, RefuseWeek) VALUES (@UPRN, @RefuseDay, @RefuseWeek)";
	try
	{
		using(var oCon = new OleDbConnection(oConStr))
		using(var sqlCon = new SqlConnection(sqlConStr))
		using(var oCmd = new OleDbCommand(oQuery, oCon))
		{
			oCon.Open();
			sqlCon.Open();
			count = 0;
			lblProcessing.Text = count.ToString();
			
			using(var dr = oCmd.ExecuteReader())
			{
				while (dr.Read())
				{
					lblProcessing.Text = "Processing: RefuseDay " + count.ToString();
					var sUPRN = dr.GetString(0);
					var sRefuseDay = dr.GetString(1);
					var iRefuseWeek = dr.GetInt32(2);
				
					using(var sqlCmd = new SqlCommand(sqlQuery, sqlCon))
					{
					   sqlCmd.Parameters.AddWithValue("@UPRN", sUPRN);
					   sqlCmd.Parameters.AddWithValue("@RefuseDay", sRefuseDay);
					   sqlCmd.Parameters.AddWithValue("@RefuseWeek", iRefuseWeek);
					   sqlCmd.ExecuteNonQuery();
					}
					count++;
				}
			}
		}
    }
	catch (Exception ex) { 
	  MessageBox.Show(ex.Message); 
	}
