    OracleDataReader reader = cmd.ExecuteReader();
    var cols = reader.FieldCount;
    
    while (reader.Read())
    {
        for (int i = 0; i < cols; i++)
        {
            Console.WriteLine("{0}: {1}", reader.GetName(i), reader.GetValue(i));
        }
    }
