     string insertCmd = "InsertIntoPicture";
     using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
      {
         conn.Open();
         SqlCommand myCommand = new SqlCommand(insertCmd, conn);
         myCommand.CommandType = CommandType.StoredProcedure;
         myCommand.Parameters.AddWithValue("@Album", txtAlbum.Text);
         myCommand.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
         myCommand.ExecuteNonQuery();
    
         int id = (int)myCommand.Parameters["@id"].Value;
       }
