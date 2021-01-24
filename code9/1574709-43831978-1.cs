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
                //table containing merged csv files
                DataTable dt = new DataTable();
                //get csv files one at a time
                foreach (string file in Directory.GetFiles(FOLDER, "*.csv"))
                {
                    //read csv file into a new dataset
                    DataSet ds = reader.ReadCSVFile(file, true);
                    //datatable containing new csv file
                    DataTable dt1 = ds.Tables[0];
                    //add new columns to datatable dt if doesn't exist
                    foreach(DataColumn col in dt1.Columns.Cast<DataColumn>())
                    {
                        //test if column exists and add if it doesn't
                        if (!dt.Columns.Contains(col.ColumnName))
                        {
                            dt.Columns.Add(col.ColumnName, typeof(string));
                        }
                    }
                    //array of column names in new table
                    string[] columnNames = dt1.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    
                    //copy row from dt1 into dt
                    foreach(DataRow row in dt1.AsEnumerable())
                    {
                        //add new row to table dt
                        DataRow newRow = dt.Rows.Add();
                        //add data from dt1 into dt
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
                    //read csv file using OLEDB Net Library
                    if (File.Exists(fullPath))
                    {
                        string ConStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + ";Extended Properties=\"Text;HDR={1};FMT=Delimited\\\"", path, headerRow ? "Yes" : "No");
                        string SQL = string.Format("SELECT * FROM {0}", filename);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, ConStr);
                        adapter.Fill(ds, "TextFile");
                        ds.Tables[0].TableName = "Table1";
                    }
                    //replace spaces in column names with underscore
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
