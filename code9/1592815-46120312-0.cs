    public CellSet GetCellSet(string connectionString, string query, IDictionary<string, object> parms)
    {
        using (var conn = new AdomdConnection(connectionString))
        {
            // Open the connection.
            conn.Open();
            // Create the command.
            using (var cmd = conn.CreateCommand())
            {
                // Set the command query.
                cmd.CommandText = query;
                // Add any query parameters.
                if (parms != null)
                {
                    foreach (var kv in parms)
                    {
                        var parameter = cmd.CreateParameter();
                        parameter.ParameterName = kv.Key;
                        parameter.Value = kv.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }
                // Execute the query and return the CellSet.
                return cmd.ExecuteCellSet();
            }
        }
    }
