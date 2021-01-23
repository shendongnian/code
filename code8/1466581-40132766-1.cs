    string insertCmd = @"INSERT INTO Picture (Album) VALUES (@Album);
                         SELECT SCOPE_IDENTITY()";
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
    {
        conn.Open();
        SqlCommand myCommand = new SqlCommand(insertCmd, conn);
        myCommand.Parameters.AddWithValue("@Album", txtAlbum.Text);
        int newID = Convert.ToInt32(myCommand.ExecuteScalar());
    }
