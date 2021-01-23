    private static IEnumerable<T> MapRecordsToDTOs<T>(SqlDataReader reader, IDataMapper<T> mapper)
    {
        var list = new List<T>(); //use a list to force eager evaluation
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                list.Add(mapper.MapToDto((IDataRecord)reader));
            }
        }
        return list.ToArray();
    }
