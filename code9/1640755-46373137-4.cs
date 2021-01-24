    void ExampleDynamicJoin(string joinColumn)
    {
        if (!ValidateColumn(joinColumn)) throw new ArgumentException();
 
        var sql = String.Format(
           "SELECT * 
            FROM TableA 
            JOIN TableB ON TableA.{0} = TableB.{0}", 
            joinColumn
        );
        var cmd = new SqlCommand()
        {
            CommandText = sql,
            CommandType = CommandType.Text,
            Connection = GetDefaultConnection()
        };
        var reader = cmd.ExecuteReader();
    }
