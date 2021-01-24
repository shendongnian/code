	const String strQuery3 = "INSERT INTO TServiceInstruments (sim, sid, sis, sih, sip, lid) VALUES (@sim, @sid, @sis, @sih, @sip, @lid)";
	using(var conection = new SqlConnection(strConnString))
	using(SqlCommand command = new SqlCommand(strQuery3, connection))
	{
		command.Parameters.Add(new SqlParameter("@sim", SqlDbType.VarChar, 200){Value = sim});
		command.Parameters.Add(new SqlParameter("@sid", SqlDbType.VarChar, 200){Value = sid});
		command.Parameters.Add(new SqlParameter("@sis", SqlDbType.VarChar, 200){Value = sis});
		command.Parameters.Add(new SqlParameter("@sih", SqlDbType.VarChar, 200){Value = sih});
		command.Parameters.Add(new SqlParameter("@sip", SqlDbType.Int){Value = sip});
		command.Parameters.Add(new SqlParameter("@lid", SqlDbType.Int){Value = lid});
		connection.Open();
		command.ExecuteNonQuery();          
	}
