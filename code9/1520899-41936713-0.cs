     int id;   
     using (connection = new SqlConnection(connectionString))
               using (SqlCommand command = new SqlCommand(query1, connection))
               {
                 connection.Open();
                 id = Convert.ToInt32(command.ExecuteScalar()); //I guess it returns only 1 id?..  
               }
