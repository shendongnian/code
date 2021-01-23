            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(commandText, connection) { CommandTimeout = 160, CommandType = commandType })
            using (var dataAdaptor = new SqlDataAdapter(command))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                dataAdaptor.Fill(dS);
            }
