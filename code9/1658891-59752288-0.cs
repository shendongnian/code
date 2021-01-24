    public static class SqliteExtensions
    {
        static async public Task<int> InsertOrReplaceAll(this SQLiteAsyncConnection connection, IEnumerable objects, bool runInTransaction = true)
        {
            var c = 0;
            if (objects == null)
                return c;
            if (runInTransaction)
            {
                await connection.RunInTransactionAsync(nonAsyncConnection =>
                {
                    foreach (var r in objects)
                    {
                        c += nonAsyncConnection.Insert(r, "OR REPLACE", Orm.GetType(r));
                    }
                });
            }
            else
            {
                foreach (var r in objects)
                {
                    c += await connection.InsertAsync(r, "OR REPLACE", Orm.GetType(r));
                }
            }
            return c;
        }
    }
