    private static Dictionary<Guid, string> foo(IEnumerable<Guid> guids, SqlConnection conn)
    {
        using (SqlCommand command = new SqlCommand(null, conn))
        {
            // use parameter as normal table in the query
            command.CommandText = 
                "select document from Documents d inner join @AllIds a ON d.id = a.Id";
            // DataTable is used for Table-Valued parameter as value
            DataTable allIds = new DataTable();
            allIds.Columns.Add("Id"); // Name of column need to be same as in created Type
            foreach(var id in guids)
                allids.Rows.Add(id);
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@AllIds",
                SqlDbType=SqlDbType.Structured // Important for table-valued parameters
                TypeName = "IdTableType", // Important! Name of the type must be provided
                Value = allIds
            };
            command.Parameters.Add(idParam);
            var documents = new Dictionary<Guid, string>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    documents[guid] = reader[0].ToString();
                }               
            }
            return documents;
        }
    }  
