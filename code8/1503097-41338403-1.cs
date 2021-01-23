	using (OleDbConnection conn = new OleDbConnection(/* connection info */))
	{
		sqlq = "SELECT COUNT(*) FROM Stock WHERE SKU = ?"
		conn.Open();
		using (OleDbCommand comm1 = new OleDbCommand(sqlq, conn))
		{
			OleDbParameter ghost1Param  = new OleDbParameter();
			comm1.Parameters.Add(ghost1Param).Value = ghost1;
			int rowCount = (int) comm1.ExecuteScalar();
			if(rowCount > 0)
			{
				sqlaq = "INSERT INTO Stock (Description, Qty, Price) VALUES (?, ?, ?)"
				using (OleDbCommand combank = new OleDbCommand(sqlaq, conn))
				{
					combank.Parameters.Add(ghost2Param).Value = ghost2;
					combank.Parameters.Add(ghost3Param).Value = ghost3;
					combank.Parameters.Add(ghost4Param).Value = ghost4;
					combank.ExecuteNonQuery();
					//Update signifies Alteration to exsisting record.
					MessageBox.Show("Insert was Successful"); //Try to use relevant messages
				}
			}
		}
	}
