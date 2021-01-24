    SqlCommand command = new SqlCommand("SELECT LP FROM [carOwners] WHERE Owner=@checkPlayerName", con);
    command.Parameters.AddWithValue("@checkPlayerName",checkPlayerName);
   
    using (SqlDataReader reader = command.ExecuteReader())
    {
      if (reader.Read())
      {
         Console.WriteLine(String.Format("{0}",reader["id"]));
       }
    }
    
    conn.Close();
