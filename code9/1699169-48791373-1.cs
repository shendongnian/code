    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication23
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                CSVReader csvReader = new CSVReader();
                DataSet ds = csvReader.ReadCSVFile(FILENAME, true);
                RegexCompare compare = new RegexCompare();
                DataTable errors = compare.Get_Error_Rows(ds.Tables[0]);
            }
        }
        class RegexCompare
        {
            public static Dictionary<string,RegexCompare> dict =  new Dictionary<string,RegexCompare>() {
                   { "SITE_ID", new RegexCompare() { columnName = "SITE_ID", pattern = @"[^\d]+", positveNegative = false, required = true}},
                   { "HOUSE", new RegexCompare() { columnName = "HOUSE", pattern = @"[^\d]+", positveNegative = false, required = true}}, 
                   { "STREET", new RegexCompare() { columnName = "STREET", pattern = @"[A-Za-z0-9 ]+", positveNegative = true, required = true}}, 
                   { "CITY", new RegexCompare() { columnName = "CITY", pattern = @"[A-Za-z ]+", positveNegative = true, required = true}},
                   { "STATE", new RegexCompare() { columnName = "STATE", pattern = @"[A-Za-z]{2}", positveNegative = true, required = true}},
                   { "ZIP", new RegexCompare() { columnName = "ZIP", pattern = @"\d{5}", positveNegative = true, required = true}},
                   { "APARTMENT", new RegexCompare() { columnName = "APARTMENT", pattern = @"\d*", positveNegative = true, required = false}},
                };
            string columnName { get; set;}
            string pattern { get; set; }
            Boolean positveNegative { get; set; }
            Boolean required { get; set; }
            public DataTable Get_Error_Rows(DataTable dt)
            {
                DataTable dtError = null;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    Boolean error = false;
                    foreach (DataColumn col in dt.Columns)
                    {
                        RegexCompare regexCompare = dict[col.ColumnName];
                        object colValue = row.Field<object>(col.ColumnName);
                        if(regexCompare.required)
                        {
                            if (colValue == null)
                            {
                                error = true;
                                break;
                            }
                            else
                            {
                                string colValueStr = colValue.ToString();
                                Match match = Regex.Match(colValueStr, regexCompare.pattern);
                                if (regexCompare.positveNegative)
                                {
                                    if (!match.Success)
                                    {
                                        error = true;
                                        break;
                                    }
                                    if (colValueStr.Length != match.Value.Length)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (match.Success)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if(error)
                    {
                        if (dtError == null) dtError = dt.Clone();
                        dtError.Rows.Add(row.ItemArray);
                    }
                }
                return dtError;
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
