    using (var conn = new NpgsqlConnection(connString))
    {
        string sQL = "insert into picturetable (id, photo) VALUES(65, @Image)";
        using (var command = new NpgsqlCommand(sQL, conn))
        {
            NpgsqlParameter param = command.CreateParameter();
            param.ParameterName = "@Image";
            param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
            param.Value = ImgByteA;
            command.Parameters.Add(param);
    
            conn.Open();
            command.ExecuteNonQuery();
        }
    }
