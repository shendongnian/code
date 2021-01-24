    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Threading;
    
    static class SqlConnectionExtensions
    {
        public static DataTable ExecuteDataTable(this SqlConnection con, string sql, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(sql, con);
            foreach (var p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            using (var dr = cmd.ExecuteReader())
            {
                var dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
    
        public static int ExecuteNonQuery(this SqlConnection con, string sql, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(sql, con);
            foreach (var p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            return cmd.ExecuteNonQuery();
        }
    
    }
    
    public partial class StoredProcedures
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void GetData(SqlString code)
        {
            Guid guid = Guid.NewGuid();
            using (var connection = new SqlConnection("context connection=true"))
            {
                connection.Open();
    
                try
                {
                    connection.ExecuteNonQuery("begin transaction;");
                    SqlContext.Pipe?.Send("Constrain");
    
                    connection.ExecuteNonQuery($"CREATE TABLE qb.{code}_{guid:N} (Id INT)");
                    
                    SqlContext.Pipe?.Send($"Create: qb.{code}_{guid:N}");
    
                    //emulate service call
                    Thread.Sleep(TimeSpan.FromSeconds(10));
    
                    SqlContext.Pipe?.Send($"Done: qb.{code}_{guid:N}");
                    connection.ExecuteNonQuery("commit transaction");
                    
                }
                catch (Exception ex)
                {
                    connection.ExecuteNonQuery("rollback;");
                    throw;
                }
         
            }
    
        }
    }
