	static class DbContextExtensions
    {
        private static object DbContextLock = new object();
        public static long GetNextFileId(this DbContext dbContext)
        {
            long fileId;
            lock (DbContextLock)
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT NEXT VALUE FOR dbo.DailyFileId;";
                    command.CommandType = CommandType.Text;
                    dbContext.Database.OpenConnection();
                    fileId = (long)command.ExecuteScalar();
                    dbContext.Database.CloseConnection();
                }
            }
            return fileId;
        }
    }
