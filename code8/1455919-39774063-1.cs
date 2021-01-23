	String sql = ConfigurationManager.ConnectionStrings["Recorder"].ConnectionString;
	using(SqlConnection connection = new SqlConnection(sql))
	using(SqlCommand command = new SqlCommand("Select PARCEL, PIN_TXT, Owner, Address1, Address2, CSZ, ACRES, LEGAL, Active FROM [ParcelView] WHERE PARCEL = @pinNum", connection))
	{
		command.Parameters.Add(new SqlParameter("@pinNum", SqlDbType.VarChar){Value = pinNum});
		using(SqlDataReader selectedParcel = command.ExecuteReader())
		{
			if (selectedParcel.Read())
			{
				/*code unchanged*/
			}
		}
		/* 1 line code unchanged*/
	}
