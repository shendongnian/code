    public static int IntFromSQL(this ApplicationDbContext context, string sql )
    {
        int count;
        using (var connection = context.Database.GetDbConnection())
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                string result = command.ExecuteScalar().ToString();
                int.TryParse(result, out count);
            }
        }
        return count;
    }
