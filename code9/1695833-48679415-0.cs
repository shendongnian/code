    public static int BulkInsert<T>(string connection, string tableName, IEnumerable<T> source)
    {
        using (var bulkCopy = new SqlBulkCopy(connection))
        {
            bulkCopy.BatchSize = 10000;
            bulkCopy.DestinationTableName = tableName;
            var reader = new EnumerableDataReader<T>(source);
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
                bulkCopy.ColumnMappings.Add(name, name);
            }
            bulkCopy.WriteToServer(reader);
            return reader.RecordsAffected;
        }
    }
