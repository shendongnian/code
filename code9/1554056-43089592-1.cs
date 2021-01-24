    public static void ProcessQueueMessage([QueueTrigger("myqueue")] string message, [Blob("mycontainer/{queueTrigger}.csv")] out string output, TextWriter log)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
    
        dt.Rows.Add("1", "fred");
    
        //your logic to query the result 
        //and generate CSV string
    
        StringBuilder sb = new StringBuilder();
    
        IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                            Select(column => column.ColumnName);
        sb.AppendLine(string.Join(",", columnNames));
    
        foreach (DataRow row in dt.Rows)
        {
            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            sb.AppendLine(string.Join(",", fields));
        }
    
    
        output = sb.ToString();
    
        log.WriteLine(message);
    }
