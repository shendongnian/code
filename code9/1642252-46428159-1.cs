	try
	{
		String query = "INSERT INTO Articolo(CodArt,Descrizione,Prezzo,PrezzoListino,Fornitore,Importato,TipoArticolo) VALUES(@CodArt,@Descrizione,@Prezzo,@PrezzoListino,@Fornitore,@Importato,@TipoArticolo)";
		String Importato = "CSV";
		String TipoArticolo = "A";
		using(SqlConnection conn = db.apriconnessione())
		using(SqlCommand cmd = new SqlCommand(query, conn))
		{
			// -1 indicates you used MAX like nvarchar(max), otherwise use the maximum number of characters in the schema
			cmd.Parameters.Add(new SqlDbParameter("@CodArt", SqlDbType.NVarChar, -1)).Value = CodiceArticolo.ToString();
			cmd.Parameters.Add(new SqlDbParameter("@Descrizione", SqlDbType.NVarChar, -1)).Value = Descrizione.ToString();
			
			/*
			  Rest of your parameters created in the same manner
			*/
			
			cmd.ExecuteNonQuery();
			db.chiudiconnessione();               
		}
		return true;
	}
	catch (Exception ex)
	{
		Console.WriteLine("Errore nell'inserimento dell'articolo " + ex);
		//MessageBox.Show("Errore nel inserimento dell'articolo:  " + ex);
		return false;
	}
