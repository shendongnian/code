    using (MySqlConnection conns2 = new MySqlConnection(connString))
    {
        conns2.Open();
        MySqlCommand comm2 = new MySqlCommand("SELECT * FROM table1", conns2);
    
        using (var reader = MySqlCommand.ExecuteReader(CommandBehavior.SchemaOnly))
        {
            reader.Read();
            var dtSchema = reader.GetSchemaTable();
    
            foreach (DataRow row in tableSchema.Rows)
	            columnlistbox.Items.Add(row["ColumnName"]);
        }
    }
