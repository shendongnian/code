    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication33
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Rows.Add(new object[] {"A", 100, DateTime.Parse("12/1/16")});
                dt.Rows.Add(new object[] { "A", 101, DateTime.Parse("12/2/16") });
                dt.Rows.Add(new object[] { "A", 102, DateTime.Parse("12/3/16") });
                dt.Rows.Add(new object[] { "A", 103, DateTime.Parse("12/4/16") });
                dt.Rows.Add(new object[] { "B", 104, DateTime.Parse("12/1/16") });
                dt.Rows.Add(new object[] { "B", 110, DateTime.Parse("12/2/16") });
                dt.Rows.Add(new object[] { "B", 114, DateTime.Parse("12/3/16") });
                dt.Rows.Add(new object[] { "B", 112, DateTime.Parse("12/4/16") });
                dt.Rows.Add(new object[] { "B", 100, DateTime.Parse("12/5/16") });
                dt.Rows.Add(new object[] { "C", 120, DateTime.Parse("12/1/16") });
                dt.Rows.Add(new object[] { "C", 130, DateTime.Parse("12/2/16") });
                dt.Rows.Add(new object[] { "C", 140, DateTime.Parse("12/3/16") });
                dt.Rows.Add(new object[] { "C", 150, DateTime.Parse("12/4/16") });
                dt.Rows.Add(new object[] { "C", 160, DateTime.Parse("12/5/16") });
                dt.Rows.Add(new object[] { "C", 101, DateTime.Parse("12/6/16") });
                string[] uniqueNames = dt.AsEnumerable().Select(x => x.Field<string>("Name")).Distinct().ToArray();
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<DateTime>("Date")).ToList();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Date", typeof(DateTime));
                foreach (var name in uniqueNames)
                {
                    pivot.Columns.Add(name, typeof(string));
                }
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["Date"] = group.Key;
                    foreach (DataRow row in group)
                    {
                        newRow[row.Field<string>("Name")] = row.Field<int>("Value");
                    }
                }
     
            }
        }
        
    }
