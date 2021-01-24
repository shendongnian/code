    // <summary>
    // Given a store datareader and a column name, try to find the column ordinal
    // in the datareader with the name of the column.
    // </summary>
    // <returns> true if found, false otherwise. </returns>
    private static bool TryGetColumnOrdinalFromReader(DbDataReader storeDataReader, string columnName, out int ordinal)
    {
        if (0 == storeDataReader.FieldCount)
        {
            // If there are no fields, there can't be a match (this check avoids
            // an InvalidOperationException on the call to GetOrdinal)
            ordinal = default(int);
            return false;
        }
    
        // Wrap ordinal lookup for the member so that we can throw a nice exception.
        try
        {
            ordinal = storeDataReader.GetOrdinal(columnName);
            return true;
        }
        catch (IndexOutOfRangeException)
        {
            // No column matching the column name found
            ordinal = default(int);
            return false;
        }
    }
