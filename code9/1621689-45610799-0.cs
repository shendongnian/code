    private T GetEntityFromDbReaderWithSingleResult<T>(DbDataReader dbReader)
    {
        if (dbReader.HasRows)
        {
            return new DataReaderReflection().DataReaderToEntity<T>(dbReader)[0];
        }
    
        return null;
    }
