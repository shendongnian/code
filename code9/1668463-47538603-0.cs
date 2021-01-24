    public static class DbContextExtensionss
    {
        public static IEnumerable<TEntity> ExecSQL<TEntity>(this DbContext context, string query) where TEntity : new()
        {
            using (var connection = context.Database.GetDbConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var entity = new TEntity();
                        foreach (PropertyInfo prop in typeof(TEntity).GetProperties())
                        {
                            if (!object.Equals(result[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(entity, result[prop.Name], null);
                            }
                        }
                        yield return entity;
                    }
                }
            }
        }
    }   
