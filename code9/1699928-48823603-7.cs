    public static class GenericTableExtensions
    {
        static object ExecWithAlias<T>(string table, Func<object> fn)
        {
            var modelDef = typeof(T).GetModelMetadata();
            lock (modelDef)
            {
                var hold = modelDef.Alias;
                try
                {
                    modelDef.Alias = table;
                    return fn();
                }
                finally
                {
                    modelDef.Alias = hold;
                }
            }
        }
        public static void DropAndCreateTable<T>(this IDbConnection db, string table)
        {
            ExecWithAlias<T>(table, () => { 
                db.DropAndCreateTable<T>();
                return null;
            });
        }
        public static long Insert<T>(this IDbConnection db, string table, T obj, bool selectIdentity = false)
        {
            return (long)ExecWithAlias<T>(table, () => db.Insert(obj, selectIdentity));
        }
        public static List<T> Select<T>(this IDbConnection db, string table, SqlExpression<T> expression)
        {
            return (List<T>)ExecWithAlias<T>(table, () => db.Select(expression));
        }
        public static int Update<T>(this IDbConnection db, string table, T item, Expression<Func<T, bool>> where)
        {
            return (int)ExecWithAlias<T>(table, () => db.Update(item, where));
        }
    }
