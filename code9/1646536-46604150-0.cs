    NpgsqlCommand cmd = new NpgsqlCommand(@"select Val, Dt from Data where idRef = :id and Dt >= :date and Dt <= :date2 order by Dt asc;", conn);
    cmd.Parameters.Add(":id", NpgsqlDbType.Integer).Value = 3;
    cmd.Parameters.Add(":date", NpgsqlDbType.Timestamp).Value = new DateTime(2017, 9, 1, 0, 0, 0);
    cmd.Parameters.Add(":date2", NpgsqlDbType.Timestamp).Value = new DateTime(2017, 10, 7, 0, 0, 0);
    conn.Open();
    using (var reader = cmd.ExecuteReader())
        while (reader.Read())
            Console.WriteLine(reader.GetString(0));
