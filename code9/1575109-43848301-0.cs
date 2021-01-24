    using(var command = new SqlCommand("SELECT * FROM Rubro WHERE Id = @GivenId", con))
    {
        try
        {
            command.Parameters.Add("@GivenId", SqlDbType.Int).Value = GivenId;
            con.Open();
            using(var reader = command.ExecuteReader())
            while (reader.Read())
            {
                rubro.Id = reader.GetInt32(0);
                rubro.Name = reader.GetString(1);
            }
            con.Close();
        }
    }
            
