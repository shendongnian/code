    using (MySqlConnection conns2 = new MySqlConnection(connString))
    {
        conns2.Open();
        MySqlCommand comm2 = new MySqlCommand("SELECT * FROM table1 WHERE 1 = 2", conns2);
    
        using (var reader = MySqlCommand.ExecuteReader())
        {
            reader.Read();
            var dtSchema = reader.GetSchemaTable();
    
            foreach (DataRow row in tableSchema.Rows)
                Console.WriteLine(row["ColumnName"]);
        }
    
    }
