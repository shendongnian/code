        string query = "INSERT INTO Rezervari (ColumnName1,ColumnName2) 
                                     VALUES (@ColumnName1,@ColumnName2)";         
        var connection = new SqlConnection(connectionString);
        var command = new SqlCommand(query, connection);
        connection.Open();
        command.Parameters.AddWithValue("@ColumnName1", "aaaa");
        command.Parameters.AddWithValue("@ColumnName2", "bbbb");
        command.ExecuteNonQuery();
        con.Close();
        }
