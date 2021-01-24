	private async void button_Click(object sender, EventArgs e)
	{
		await readWriteRefuseDayAsync();
	}
	private async Task readWriteRefuseDayAsync() {
	  const string oQuery = "SELECT UPRN, RefuseDay, RefuseWeek FROM RefuseDay";
	  const string sqlQuery = "INSERT INTO Ref_RefuseDay (UPRN, RefuseDay, RefuseWeek) VALUES (@UPRN, @RefuseDay, @RefuseWeek)";
	  try {
	  	using(var oCon = new OleDbConnection(oConStr))
	  	using(var sqlCon = new SqlConnection(sqlConStr))
	  	using(var oCmd = new OleDbCommand(oQuery, oCon))
	  	{
	  		await oCon.OpenAsync();
	  		await sqlCon.OpenAsync();
	  		count = 0;
	  		lblProcessing.Text = count.ToString();
	  		
	  		using(var dr = await oCmd.ExecuteReaderAsync())
	  		{
	  			while (await dr.ReadAsync())
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
	  				   await sqlCmd.ExecuteNonQueryAsync();
	  				}
	  				count++;
	  			}
	  		}
	  	}
	  }
	  catch (Exception ex) {
		MessageBox.Show(ex.Message); 
	  }
	}
