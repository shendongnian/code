    NpgsqlCommand command = new NpgsqlCommand("select * from Function1(:ID, :DATE1, :DATE2)",
        connection);
    command.Parameters.Add(new NpgsqlParameter("ID", NpgsqlDbType.Integer));
    command.Parameters.Add(new NpgsqlParameter("DATE1", NpgsqlDbType.Date));
    command.Parameters.Add(new NpgsqlParameter("DATE2", NpgsqlDbType.Date));
    command.Parameters[0].Value = id;
    command.Parameters[1].Value = dt1;
    command.Parameters[2].Value = dt2;
    DataTable dtResults = new DataTable();
    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
    da.Fill(dtResults);
