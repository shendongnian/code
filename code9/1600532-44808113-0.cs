    IEnumerable<IDictionary<string, object>> results;
    string sql = @"select 'a' as col1, 'b' as col2, 'c' as col3, 'd' as col4
                   union
                   select 'w' as col1, 'x' as col2, 'y' as col3, 'z' as col4";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
                
        results = connection.Query(sql) as IEnumerable<IDictionary<string, object>>;
    }
    //we need to use ElementAt as we have an Enumerable but we could ToList it if required
    Console.WriteLine(results.ElementAt(0)["col1"]);
    //we can iterate the rows
    foreach (var row in results)
    {
        //then iterate the columns and get a KeyValuePair for each column
        foreach (var col in row)
        {
            Console.WriteLine("{0} {1}", col.Key, col.Value);
        }
    }
	
