    private T GetEntityFromDbReaderWithSingleResult<T>(DbDataReader dbReader) where T : new()
    {
        if (dbReader.HasRows)
        {
            return new DataReaderReflection().DataReaderToEntity<T>(dbReader)[0];
        }
    
        return default(T);
    }
