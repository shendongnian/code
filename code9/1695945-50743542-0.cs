        public void Dispose()
        {
            // disposing other stuff 
            // sql db
            if (Directory.Exists(this.destinationDirectory))
            {
                DetachDatabase(this.connectionString);
                Directory.Delete(this.destinationDirectory, true);
            }
        }
        public static void DetachDatabase(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql = "DECLARE @dbName NVARCHAR(260) = QUOTENAME(DB_NAME());\n" +
                              "EXEC('ALTER DATABASE ' + @dbName + ' SET OFFLINE WITH ROLLBACK IMMEDIATE;');\n" + 
                              "EXEC('exec sp_detach_db ' + @dbName + ';');";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }
