    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
                OleDbConnection conn = new OleDbConnection("Enter Connection String Here");
                string abfrage = "Enter Query Here";
                OleDbCommand cmd = new OleDbCommand(abfrage, conn);
                OleDbDataReader dr;
                List<string> Provider = new List<string>();
                int colIndex = 3;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Provider.Add(dr.GetString(colIndex));
                    }
                    dr.Close();
                    dr.Dispose();
                }
                catch (System.InvalidOperationException inv)
                {
                    MessageBox.Show(inv.Message);
                    throw;
                }
            }
        }
    }
