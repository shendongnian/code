            var result = 0;
            
            var connectionString = ConfigurationManager.ConnectionStrings["your_connection"].ConnectionString;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("CALL new_procedure()", connection);
                result = int.Parse(command.ExecuteScalar().ToString());
                MySql.Data.MySqlClient.MySqlConnection.ClearPool(connection);
                connection.Close();                 
            }
            
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("CALL new_procedure()", connection);
                result = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();                
            }
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("CALL new_procedure()", connection);
                result = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();                
            }    
 
