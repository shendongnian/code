            using (SqlConnection connection = GetConnection.GetConnectionObject())
            {
                //TODO parametreleri command.parameters yoluyla alsın
                var command = new SqlCommand
                {
                    CommandText = "select * from windowsserv",
                    Connection = connection
                };
    
                if (connection.State != ConnectionState.Open)
                    connection.Open();
    
                Console.WriteLine("Connection opened");
                var rdr = command.ExecuteReader();
    
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + "--" + rdr[1]);
                }
            }
