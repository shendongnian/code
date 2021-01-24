    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace ConsoleApp11
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                //var EmployeeIDs = File.ReadAllLines(""/* Filepath */);
                var EmployeeIDs = Enumerable.Range(1, 30 * 1000).ToList();
                var dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
    
                dt.BeginLoadData();
                foreach (var id in EmployeeIDs)
                {
                    var row = dt.NewRow();
                    row[0] = id;
                    dt.Rows.Add(row);
                }
                dt.EndLoadData();
                    
                using (SqlConnection conn = new SqlConnection("server=.;database=tempdb;integrated security=true"))
                {
                    conn.Open();
    
                    var cmdCreateTemptable = new SqlCommand("create table #ids(id int primary key)",conn);
                    cmdCreateTemptable.ExecuteNonQuery();
    
                    //var cmdCreateEmpable = new SqlCommand("create table Employees(EmployeeId int primary key, FirstName varchar(2000))", conn);
                    //cmdCreateEmpable.ExecuteNonQuery();
    
    
                    var bc = new SqlBulkCopy(conn);
                    bc.DestinationTableName = "#ids";
                    bc.ColumnMappings.Add("id", "id");
                    bc.WriteToServer(dt);
    
                    var names = new List<string>();
                    var cmd = new SqlCommand("SELECT FirstName, EmployeeId FROM Employees WHERE EmployeeID in (select id from #ids)", conn);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        var firstName = rdr.GetString(0);
                        var id = rdr.GetInt32(1);
                        names.Add(firstName);
                    }
    
                    Console.WriteLine("Hit any key to continue");
                    Console.ReadKey();
                }
    
    
    
            }
    
          
        }
    }
