    using (var bcp = new SqlBulkCopy("connectionString", SqlBulkCopyOptions.UseInternalTransaction))
    using (var rdr = new CsvReader(new StreamReader("data.csv"), false))
    {
        bcp.BatchSize = 500;
        bcp.DestinationTableName = "test_table";
        bcp.NotifyAfter = 500;
        bcp.SqlRowsCopied += (sender, e) =>
        {
            Console.WriteLine("Written: " + e.RowsCopied.ToString());
        };
        bcp.WriteToServer(rdr);
    
    }
