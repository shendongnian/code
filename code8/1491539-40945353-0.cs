    private static Dictionary<Guid, string> foo(IEnumerable<Guid> guids, SqlConnection conn)
    {
        using (SqlCommand command = new SqlCommand(null, conn))
        {
            // use parameter as normal table in the query
            command.CommandText = 
                "select document from Documents d inner join @AllIds all ON d.id = all.Id";
            // DataTable is used for Table-Valued parameter as value
            DataTable allIds = new DataTable { Columns = {"Id"} };
            foreach(var id in guids)
                allids.Rows.Add(id);
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@AllIds",
                TypeName = "IdTableType", // Important! Name of the type must be provided
                Value = allIds
            };
            command.Parameters.Add(idParam);
            command.Prepare();
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
