    private IEnumerable<IEnumerable<DataRow>> GetChunks(DataTable table, int size)
    {
        List<DataRow> chunk = new List<DataRow>(size);
        foreach (DataRow row in table.Rows)
        {
            chunk.Add(row);
            if (chunk.Count == size)
            {
                yield return chunk;
                chunk = new List<DataRow>(size);
            }
        }
        if(chunk.Any()) yield return chunk;
    }
    //....
    DataTable table = dataSet.Tables[yourTable];
    var chunks = GetChunks(table, 100);
    foreach (IEnumerable<DataRow> chunk in chunks)
        SendChunk(chunk); // <-- Send your chunk of DataRow to webservice
    
