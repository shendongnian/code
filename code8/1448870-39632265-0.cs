    string inputPath = "YourInputFile";
    using (var conn = new SqlConnection(YourConnectionString))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            // note we define a '@blob' parameter in the SQL text
            cmd.CommandText = "INSERT INTO MyTable (Id, MyBlobColumn) VALUES (1, @blob)";
            using (var inputStream = File.OpenRead(inputPath))
            {
                // open the file and map it to an SqlBytes instance
                // that we use as the parameter value.
                var bytes = new SqlBytes(inputStream);
                cmd.Parameters.AddWithValue("blob", bytes);
                
                // undercovers, the reader will suck the inputStream out through the SqlBytes parameter
                cmd.ExecuteNonQuery();
            }
        }
    }
            
