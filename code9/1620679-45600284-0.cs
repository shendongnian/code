    Set1 set1 = null;
    var set2 = new List<Set2>();
    Set3 set3 = null;
    using (var command = new SqlCommand("sp", conn))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(parameters);
        command.Connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.FieldCount > 0)
            {
                var set1Parser = reader.GetRowParser<Set1>();
                var set2Parser = reader.GetRowParser<Set2>();
                var set3Parser = reader.GetRowParser<Set3>();
                var isSet1 = HasColumn(reader, "Set1_UniqueColumnName");
                var isSet2 = HasColumn(reader, "Set2_UniqueColumnName");
                var isSet3 = HasColumn(reader, "Set3_UniqueColumnName");
                
                while (reader.Read())
                {
                    if (isSet1)
                    {
                        set1 = set1Parser(reader);
                    }
                    else if (isSet2)
                    {
                        set2.Add(set2Parser(reader));
                    }
                    else if (isSet3)
                    {
                        set3 = set3Parser(reader);
                    }
                }
                reader.NextResult();
            }
        }
    }
