    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("foo"));
    
                for (int i = 0; i < 3; i++)
                {
                    FillIt(dt);
                }
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine(dt.Rows[i][0]);
                }
    
                Console.ReadKey();
            }
    
            private static void FillIt(DataTable dtin)
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlConnection cnxn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT 'bar' AS [foo];", cnxn);
                da.SelectCommand = cmd;
    
                da.Fill(dtin);
            }
        }
    }
