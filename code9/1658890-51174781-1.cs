    static public class SQLiteConnectionExtensions
    {
        /// <summary>
        ///     Inserts all specified objects.
        ///     For each insertion, if a UNIQUE
        ///     constraint violation occurs with
        ///     some pre-existing object, this function
        ///     deletes the old object.
        /// </summary>
        /// <param name="objects">
        ///     An <see cref="IEnumerable" /> of the objects to insert or replace.
        /// </param>
        /// <returns>
        ///     The total number of rows modified.
        /// </returns>
        static public int InsertOrReplaceAll(this SQLiteConnection connection, IEnumerable objects, bool runInTransaction = true)
        {
            var c = 0;
            if (objects == null)
                return c;
            
            if (runInTransaction)
            {
                connection.RunInTransaction(() =>
                {
                    foreach (var r in objects)
                    {
                        c += connection.Insert(r, "OR REPLACE", Orm.GetType(r));
                    }
                });
            }
            else
            {
                foreach (var r in objects)
                {
                    c += connection.Insert(r, "OR REPLACE", Orm.GetType(r));
                }
            }
            return c;
        }
    }
