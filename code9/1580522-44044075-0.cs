    using (OleDbConnection con = new OleDbConnection(RegistarBlagajna.Modul.VezaNaBazu.ConnectionString))
    {
        try
        {
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(@"UPDATE FisDnevni SET [JIR] = @JIR, [Paragon] = @Paragon WHERE BrojRacuna = @BrojRacuna", con)
            {
                 cmd.Parameters.AddWithValue("@JIR", racun.JIR.Substring(0,37));
                 // this must be the second parameter instead of third one
                 cmd.Parameters.AddWithValue("@Paragon", racun.Paragon);
                 cmd.Parameters.AddWithValue("@BrojRacuna", racun.BrojRacuna);
                 cmd.ExecuteNonQuery();
                 con.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
