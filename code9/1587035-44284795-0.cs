    List<String> column14Values = new List<String>();
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        
        using(var command = new SqlCommand(myQuery, connection))
        {
              var reader = command.ExecuteReader();
      
              while(reader.Read())
              {
                   string theFourteenthColumnValue = reader.GetFieldValue<string>(13);
    
                   column14Values.Add(theFourteenthColumnValue); 
              }
        }
    }
    
    return column14Values;
