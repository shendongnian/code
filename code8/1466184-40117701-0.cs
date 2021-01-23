    var query = "select * from ValidId where id=@id";
    using (var conn = new System.Data.SqlClient.SqlConnection(usingConnectionString))
    {
        using (var command = new System.Data.SqlClient.SqlCommand(query, conn))
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            conn.Open();
            using (var adapter = new System.Data.SqlClient.SqlDataAdapter(command))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Test = reader["Id"].ToString();
                    }                    
                }
            }
            command.Parameters.Clear();
        }
    }
