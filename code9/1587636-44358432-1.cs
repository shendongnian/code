    public class MyDBConfiguration : DbConfiguration
    {
        public MyDBConfiguration()
        {
            DbInterception.Add(new EntityFrameworkInterceptor());
        }
    }
    public class EntityFrameworkInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            var path = @"C:\Users\maine\Documents\result.json";
            var serialized = JsonConvert.SerializeObject(command, new DbCommandSerializer());
            File.WriteAllText(path, serialized);
        }
    }
