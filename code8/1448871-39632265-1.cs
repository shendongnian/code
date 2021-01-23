    string outputPath = "YourOutputFile";
    using (var conn = new SqlConnection(YourConnectionString))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            // this is a regular direct SQL command, but you can use a stored procedure as well
            cmd.CommandText = "SELECT MyBlobColumn FROM MyTable WHERE Id = 1";
            
            // note the usage of SequentialAccess to lower memory consumption (read the docs for more)
            using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                if (reader.Read())
                {
                    // again, we map the result to an SqlBytes instance
                    var bytes = reader.GetSqlBytes(0); // column ordinal, here 1st column -> 0
                    
                    // I use a file stream, but that could be any stream (asp.net, memory, etc.)
                    using (var file = File.OpenWrite(outputPath))
                    {
                        bytes.Stream.CopyTo(file);
                    }
                }
            }
        }
    }
