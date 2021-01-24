    DataTable ExampleDynamicJoin(string joinColumn)
    {
        if (!ValidateColumn(joinColumn)) throw new ArgumentException();
        var sql = String.Format(
          @"SELECT * 
            FROM TableA 
            JOIN TableB ON TableA.{0} = TableB.{0}", 
            joinColumn
        );
 
        using (var connection = GetConnectionFromSomewhere())
        {
            using (var cmd = new SqlCommand
            {   
                CommandText = sql,
                CommandType = CommandType.Text,
                Connection = connection
            })
            {
                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
    }
