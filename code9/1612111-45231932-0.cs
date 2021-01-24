    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable rs = new DataTable();
    
                using (var odConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\Users\IIG\Desktop\test.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
                {
                    odConnection.Open();
    
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = odConnection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM [Sheet2$]";
                        using (OleDbDataAdapter oleda = new OleDbDataAdapter(cmd))
                        {
                            oleda.Fill(rs);
                        }
                    }
                    odConnection.Close();
                }
                foreach(DataRow row in rs.Rows)
                {
                    foreach(object item in row.ItemArray)
                    {
                        Console.Write(item +"\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
