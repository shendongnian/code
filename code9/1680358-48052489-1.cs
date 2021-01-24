	var dicStatus = new Dictionary<int, string> { 
		{ 0, "Pending" }, 
		{ 1, "Booked"  },
		{ 2, "Cancelled" }
        // ...
	};
	
	string querySql = " SELECT * FROM View_Booking" +
					  " WHERE CAST(bkID AS NVARCHAR(10)) LIKE @bkID" + 
					  " OR bkSlot LIKE @bkSlot" +
					  " OR bkStatus = @status";
	using (SqlConnection dbConn = new SqlConnection(connectionString))
	{
		dbConn.Open();
		using (SqlCommand sqlCommand = new SqlCommand(querySql, dbConn))
		{
			sqlCommand.Parameters.Add("@bkID", SqlDbType.VarChar).value ="%" + keyword + "%";
			sqlCommand.Parameters.Add("@bkSlot", SqlDbType.VarChar).value ="%" + keyword + "%";
			sqlCommand.Parameters.Add("@status", SqlDbType.int).value = dicStatus.FirstOrDefault(x => x.Value == keyword).Key;
			sqlCommand.ExecuteNonQuery();
		 }
	}
