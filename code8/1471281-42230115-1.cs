    using System;
    using SQLitePCL.pretty;
    using System.Text.RegularExpressions;
    
    namespace TestSqlite
    { 
        class Program
        {
            static void Main(string[] args)
            {
                Func<ISQLiteValue, ISQLiteValue, ISQLiteValue> regexFunc =
                            (ISQLiteValue val, ISQLiteValue regexStr) =>
                            {
                                if (Regex.IsMatch(Convert.ToString(val), Convert.ToString(regexStr)))
                                    return true.ToSQLiteValue();
                                return false.ToSQLiteValue();
                            };
                SQLitePCL.Batteries.Init();
                SQLiteDatabaseConnection _dbcon = SQLiteDatabaseConnectionBuilder
                            .InMemory
                            .WithScalarFunc("REGEXP", regexFunc)
                            .Build();
                string sql = "CREATE TABLE foo (a int, b text);";
                _dbcon.ExecuteAll(sql);
                _dbcon.ExecuteAll(@"INSERT INTO foo VALUES (1, 'this is me');
                                    INSERT INTO foo VALUES (2, 'that is me');
                                    INSERT INTO foo VALUES (3, 'he is me');");
                sql = "SELECT * FROM foo where '\\w{4} is me' REGEXP b;";
                foreach (var row in _dbcon.Query(sql)) { Console.WriteLine(row[1].ToString()); }
            }
        }
    }
