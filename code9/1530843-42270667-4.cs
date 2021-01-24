    public async Task DataTableToCsv(DataTable table, string file,CancellationToken token)
    {
    ...
        foreach(var row in myTable)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }
            //else continue with processing
            var line=String.Join(",", row.ItemArray);
            await writer.WriteLineAsync(line);
        }
