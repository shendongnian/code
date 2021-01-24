    private const string C_SqlConnectionString = @"Server=SERVERNAME;Database=DBNAME;Trusted_Connection=yes;";
    private const int C_FileChunkSizeBytes = 1024 * 1024; // 1 MB
    private static void storeFile(string filepath)
    {
        using (FileStream fs = File.Open(filepath, FileMode.Open))
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = C_SqlConnectionString;
                conn.Open();
                // Use a transaction to ensure that all parts of the file get stored to DB
                SqlCommand command = new SqlCommand("BEGIN TRAN", conn);
                command.ExecuteNonQuery();
                var pos = 0;
                byte[] fileBytes = null;
                int sqlRowId = 0;
                // Read the file in chunks
                while (pos < fs.Length)
                {
                    // Read file bytes
                    var bytesToRead = pos + C_FileChunkSizeBytes < fs.Length
                        ? C_FileChunkSizeBytes
                        : (int)(fs.Length - pos);
                    fileBytes = new byte[bytesToRead];
                    fs.Read(fileBytes, 0, bytesToRead);
                    // Store bytes to a parameter
                    var varbinary = new SqlParameter("0", System.Data.SqlDbType.VarBinary, -1);
                    varbinary.Value = fileBytes;
                    if (pos == 0)
                    {
                        // If this is the first chunk, then we need to INSERT
                        // The HOLDLOCK hint will hold a lock on the table until transaction completes (or is rolled back)
                        command = new SqlCommand("INSERT INTO [dbo].[table1] WITH(HOLDLOCK) VALUES(@0)", conn);
                        command.Parameters.Add(varbinary);
                        command.ExecuteNonQuery();
                        // Get the row ID for the inserted row
                        command = new SqlCommand("SELECT @@IDENTITY", conn);
                        sqlRowId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        // Update existing row and append data
                        command = new SqlCommand("UPDATE [dbo].[table1] SET [Data] = [Data] + @0 WHERE [ID] = @1", conn);
                        command.Parameters.Add(varbinary);
                        command.Parameters.Add(new SqlParameter("1", System.Data.SqlDbType.Int)).Value = sqlRowId;
                        command.ExecuteNonQuery();
                    }
                    // ** Good place for a breakpoint
                    pos += bytesToRead;
                }
                // Commit transaction
                command = new SqlCommand("COMMIT TRAN", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
