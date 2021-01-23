    public void QueryToDatabase(string commandText, Gebruikerklasse gebruiker)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(commandText, conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@Naam", gebruiker.Naam);
            cmd.Parameters.AddWithValue("@Achternaam, gebruiker.Achternaam);
            // do the same with others properties in gebruiker
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
