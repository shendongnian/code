using System;
using System.Threading.Tasks;
using SQLite;
namespace MyApp.DB
{
    public class Row<T>
    {
        public T scalar_value { get; set; }
    }
    public class Maybe<T>
    {
        public readonly T Value;
        public Maybe(T v) { Value = v;  }
    }
    public static class SQLiteExtensions
    {
        public async static Task<Maybe<T>> QueryScalarAsync<T>(this SQLite.SQLiteAsyncConnection conn, string sql)
        {
            var res = await conn.QueryAsync<Row<T>>(sql);
            if (res.Count == 0)
            {
                return null;
            }
            else
            {
                return new Maybe<T>(res[0].scalar_value);
            }
        }
    }
}
A return value of `null` signifies no rows found and any return value itself is wrapped in a `Maybe` class so that null values can be distinguished:
var version = await conn_.QueryScalarAsync<int>("SELECT version AS scalar_value FROM schema_version");
if (version == null)
{
    Debug.WriteLine("no rows found");
}
else
{
    Debug.WriteLine(string.Format("value = {0}", version.Value));
}
The only gotcha is that your query must include a column named `scalar_value`.
