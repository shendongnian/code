    List<string> results = new List<string>();
    String query2 = "SELECT PerfilId FROM Seguridad.UsuarioPerfil WHERE UsuarioID = @USARIO";
    SqlCommand cmd = new SqlCommand(query2, connection);
    cmd.Parameters.Add(new SqlParameter("@USARIO", SqlDbType.VarChar));
    cmd.Parameters[0].Value = UsuarioID;
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        results.Add(reader.GetString(0));
    }
    reader.Close();
