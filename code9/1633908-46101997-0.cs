    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var con = new SqlConnection("Server=localhost;database=tempdb;integrated security=true"))
                {
                    con.Open();
    
                    var ddl = new SqlCommand(@"
    CREATE OR ALTER PROCEDURE [dbo].[proc_getproductslist]
        @idProducts varchar(max)
    AS
    BEGIN
    
        DECLARE @SQL nvarchar(max)
    
        SET @SQL = 'SELECT ''success'' result WHERE ''1'' IN ('+@idProducts +')'
    
        EXEC sp_executesql @SQL
    END
    ", con);
                    ddl.ExecuteNonQuery();
    
                    var cmd = new SqlCommand("proc_getproductslist", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
                    cmd.Parameters.Add("@idProducts", SqlDbType.VarChar).Value = "'''1'',''2'''";
                    
    
                    var result = (string)cmd.ExecuteScalar() ;
                    Console.WriteLine(result??"null");
    
                    cmd.Parameters["@idProducts"].Value = "'1','2'";
                    result = (string)cmd.ExecuteScalar();
    
                    Console.WriteLine(result??null);
    
                    Console.ReadKey();
    
                }
            }
        }
    }
