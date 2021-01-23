    using (var con = new SqlConnection(ConfigurationManager.AppSettings["db"]))
    {
        con.Open();
        var sql = "INSERT INTO Fisier (idFisier, Nume, idFolder) VALUES (@idFisier, @nume, @idFolder)";
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.Add("@idFisier", SqlDbType.VarChar).Value = idFis.Text;
            cmd.Parameters.Add("@nume", SqlDbType.VarChar).Value = numeFis.Text;
            cmd.Parameters.Add("@idFolder", SqlDbType.VarChar).Value = idFoldFis.Text;
            cmd.ExecuteNonQuery();
        }
    } // Closing is now handled for you (even if errors occur)
