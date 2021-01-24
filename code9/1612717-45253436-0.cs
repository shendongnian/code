    var sb = new StringBuilder();
    sb.AppendLine("sep=,");
    sb.AppendLine("COL1,COL2,COL3,...,COL-N"); // columns
    using (IDataReader reader = dbInstance.ExecuteReader(dbCommand))
    {
        DataRow newRow;
        while (reader.Read())
        {
            sb.Append((string)reader["COL1"] + ",");
            sb.Append((string)reader["COL2"] + ",");
            sb.Append((string)reader["COL3"] + ",");
            ...
            sb.Append((string)reader["COL-N"] + Environment.NewLine);
        }
    }
    
    return sb.ToString(); // returns string representing CSV file content
