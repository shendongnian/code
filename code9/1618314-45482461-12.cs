	static class DbContextExtensions
    {
        private static object DbContextLock = new object();
		public static void ResetSquence(this DbContext dbContext)
		{
			lock (DbContextLock)
			{
				using (var command = dbContext.Database.GetDbConnection().CreateCommand())
				{
					command.CommandText = @"Set @YY = (RIGHT(CONVERT(VARCHAR(8), GETDATE(), 1),2))
	Set @MM =  SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2)
	Set @DD =  RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(DAY, GETDATE())), 2)
	DROP SEQUENCE IF EXISTS dbo.DailyFileId;
	CREATE SEQUENCE dbo.DailyFileId
	START WITH CAST(CONCAT(@YY, @MM, @DD, '0001') AS int)
	INCREMENT BY 1;  
	GO  ";
					command.CommandType = CommandType.Text;
					dbContext.Database.OpenConnection();
					command.ExecuteNonQuery();
					dbContext.Database.CloseConnection();
				}
			}
		}
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
