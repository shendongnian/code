    string query = $@"
    #legacySQL
    SELECT
      visitorId,
      visitNumber,
      visitId,
      visitStartTime,
      date,
      hits.hitNumber as hitNumber,
      hits.product.productSKU as product.productSKU
    FROM 
      FLATTEN(FLATTEN({tableName},hits),hits.product)";
    
    //Creating a job for the query and activating legacy sql
    
                BigQueryJob job = client.CreateQueryJob(query,
                    new CreateQueryJobOptions { UseLegacySql = true });
    
                BigQueryResults queryResult = client.GetQueryResults(job.Reference.JobId,
                    new GetQueryResultsOptions());
    
                StringBuilder sb = new StringBuilder();
    
    //Getting the headers from the GA table and write them into the first row of the new table
    
                int count = 0;
                for (int i = 0; i <= queryResult.Schema.Fields.Count() - 1; i++)
                {
                    string columenname = "";
                    var header = queryResult.Schema.Fields[0].Name;
                    if (i + 1 >= queryResult.Schema.Fields.Count)
                        columenname = queryResult.Schema.Fields[i].Name;
                    else
                        columenname = queryResult.Schema.Fields[i].Name + ",";
                    sb.Append(columenname);
                }
    
    //Getting the data from the GA table and write them row by row into the new table
    
                sb.Append(Environment.NewLine);
                foreach (var row in queryResult.GetRows())
                {
    
                    count++;
                    if (count % 1000 == 0)
                        Console.WriteLine($"item {count} finished");
                    int blub = queryResult.Schema.Fields.Count;
                    for (Int64 j = 0; j < Convert.ToInt64(blub); j++)
                    {
                        try
                        {
                            if (row.RawRow.F[Convert.ToInt32(j)] != null)
                                sb.Append(row.RawRow.F[Convert.ToInt32(j)].V + ",");
    
                        }
                        catch (Exception)
                        {
    
                        }
                    }
                    sb.Append(Environment.NewLine);
    
                }
