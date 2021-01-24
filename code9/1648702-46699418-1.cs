    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExcelReadOnly
    {
        class Program
        {
            static void Main(string[] args)
            {
                PreProcess("Sample File.xlsx");
                Console.In.ReadLine();
            }
    
            public static bool PreProcess(string dbpath)
            {
                string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbpath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;\";";
    
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
    
                    var cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader?.Read() == true)
                        Console.Out.WriteLine($"Name: {reader[0]}, Par1: {reader[1]}");
                    reader?.Close();
    
                    new OleDbCommand("INSERT INTO [Sheet1$] ([Name], [Par1]) VALUES ('Name 0', '0')", conn)
                        .ExecuteNonQuery();
                    new OleDbCommand("INSERT INTO [Sheet1$] ([Name], [Par1]) VALUES ('Name 1', '1')", conn)
                        .ExecuteNonQuery();
                    new OleDbCommand("INSERT INTO [Sheet1$] ([Name], [Par1]) VALUES ('Name 2', '2')", conn)
                        .ExecuteNonQuery();
    
                    reader = cmd.ExecuteReader();
                    while (reader?.Read() == true)
                        Console.Out.WriteLine($"Name: {reader[0]}, Par1: {reader[1]}");
                    reader?.Close();
                }
    
                return false;
            }
        }
    }
