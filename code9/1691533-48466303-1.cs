    SqlCommand command = new SqlCommand("SELECT LP FROM [carOwners] WHERE Owner=@checkPlayerName", con);
    command.Parameters.AddWithValue("@checkPlayerName",checkPlayerName);
   
    using (SqlDataReader reader = command.ExecuteReader())
    {
      while (reader.Read())
      {
         Console.WriteLine(String.Format("{0}",reader["id"]));
       }
    }
    
    conn.Close();
