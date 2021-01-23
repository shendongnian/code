    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema("filename");
                string SQL = "SELECT QUERY";
                string connStr = "Enter you connection string here";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                adapter.Fill(ds);
                ds.WriteXml("filename");
            }
        }
    }
