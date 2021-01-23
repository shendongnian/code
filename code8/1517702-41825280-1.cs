	var query = "INSERT INTO Acteurs (voornaam, achternaam, FilmID) SELECT @a1Voornaam, @a1Achternaam, FilmID from Films WHERE titel = @title";
	using(var con = new SqlConnection("connection string here"))
	using(var command = new SqlCommand(queryString, con))
	{
	  command.Parameters.Add(new SqlParameter("@a1Voornaam", SqlDbType.VarChar){Value = a1Voornaam});
	  command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.VarChar){Value = achternaam});
	  command.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar){Value = title});
	  
	  con.Open();
	  command.ExecuteNonQuery();
	}
