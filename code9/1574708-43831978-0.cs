    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FOLDER = @"c:\temp\test";
            static void Main(string[] args)
            {
                CSVReader reader = new CSVReader();
                DataTable dt = new DataTable();
                
                foreach (string file in Directory.GetFiles(FOLDER, "*.csv"))
                {
                    DataSet ds = reader.ReadCSVFile(file, true);
                    DataTable dt1 = ds.Tables[0];
                    foreach(DataColumn col in dt1.Columns.Cast<DataColumn>())
                    {
                        if (!dt.Columns.Contains(col.ColumnName))
                        {
                            dt.Columns.Add(col.ColumnName, typeof(string));
                        }
                    }
                    string[] columnNames = dt1.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    foreach(DataRow row in dt1.AsEnumerable())
                    {
                        DataRow newRow = dt.Rows.Add();
                        for(int i = 0; i < columnNames.Count(); i++)
                        {
                            newRow[columnNames[i]] = row[columnNames[i]];
                        }
                    }
                }
            }
        }
        public class CSVReader
        {
            public DataSet ReadCSVFile(string fullPath, bool headerRow)
            {
                string path = fullPath.Substring(0, fullPath.LastIndexOf("\\") + 1);
                string filename = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                DataSet ds = new DataSet();
                try
                {
                    if (File.Exists(fullPath))
                    {
                        string ConStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + ";Extended Properties=\"Text;HDR={1};FMT=Delimited\\\"", path, headerRow ? "Yes" : "No");
                        string SQL = string.Format("SELECT * FROM {0}", filename);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, ConStr);
                        adapter.Fill(ds, "TextFile");
                        ds.Tables[0].TableName = "Table1";
                    }
                    foreach (DataColumn col in ds.Tables["Table1"].Columns)
                    {
                        col.ColumnName = col.ColumnName.Replace(" ", "_");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return ds;
            }
        }
    }
