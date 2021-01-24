    static private DataTable GetData_(string connectionString, string sqlSelect, Hashtable arg,
                                      bool doFillSchema, ref DataTable schemaTable)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(sqlSelect, connection))
        {
            connection.Open();
            // If we want the schema, do the extra step.
            if (doFillSchema)
            {
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                    schemaTable = reader.GetSchemaTable();
            }
            // Use the adapter to fill the result table..
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable table = new DataTable();
                // Set the SELECT arguments.
                if (arg != null)
                {
                    foreach (DictionaryEntry item in arg)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                }
                // Get the result of the SQL query.
                adapter.Fill(table);
                return table;
            }
        }
    }
    
