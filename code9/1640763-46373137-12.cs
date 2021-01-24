    DataTable ExampleDynamicJoin(string joinColumn)
    {
        if (!ValidateColumn(joinColumn)) throw new ArgumentException();
 
        using (var connection = GetConnectionFromSomewhere())
        using (var cmd = new SqlCommand())
        {
            var sql = String.Format(
              @"SELECT * 
                FROM TableA 
                JOIN TableB ON TableA.{0} = TableB.{0}", 
                joinColumn
            );
            var cmd = new SqlCommand()
            {
                CommandText = sql,
                CommandType = CommandType.Text,
                Connection = connection
            };
            var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }
    }
