	Client client = null;
	string sqlQuery = "SELECT Nome, Cognome, Giorno_Nascita, Mese_Nascita, Anno_Nascita, Luogo_Nascita, Residenza, Provincia_Residenza, Indirizzo_Residenza, Civico_Residenza, Domicilio, Provincia_Domicilio, Indirizzo_Domicilio, Civico_Domicilio, Mail, Telefono_Fisso, Telefono_Mobile, Fax, Codice_Fiscale " +
	"FROM DatiClienti " +
	"WHERE Nome LIKE  @name AND Cognome LIKE  @surname";
	using (SqlConnection con = new SqlConnection("Your Connection, ideally from an app.config"))
	using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
	{
		con.Open();
		cmd.Parameters.Add(new SqlDbParameter("@name", SqlDbType.VarChar, 200){Value = name}); // specify the correct DbType and Length
		cmd.Parameters.Add(new SqlDbParameter("@surname", SqlDbType.VarChar, 200){Value = surname}); // specify the correct DbType and Length
		using(var reader = cmd.ExecuteReader())
		{
			if(dbReader.Read())
			{
				client = new Client();
				client.Nome = reader.GetString(0);
				client.Cognome = reader.GetString(1);
				client.GiornoNascita = reader.GetString(2);
				client.MeseNascita = reader.GetString(3);
				// etc
			}
		}
	}
	return client;
