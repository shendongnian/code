    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using CsvHelper;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string savetopath = @"C:\Users\myusername\Desktop\test.csv";
                DataTable table = new DataTable();
                table.Columns.Add("Column A", typeof(string));
                table.Rows.Add("056");
    
                using (StreamWriter streamwriter = new StreamWriter(savetopath))
                {
                    using (CsvWriter csv = new CsvWriter(streamwriter))
                    {
                        List<string> columns = new List<string>();
                        foreach (DataColumn column in table.Columns)
                            csv.WriteField(column.ColumnName.ToString());
    
                        csv.NextRecord();
    
                        foreach (DataRow row in table.Rows)
                        {
                            for (var i = 0; i < table.Columns.Count; i++)
                            {
                                csv.WriteField(row[i].ToString());
                            }
                            csv.NextRecord();
                        }
                    }
                }
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }
    }
