    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("unit", typeof(string));
                dt.Columns.Add("value", typeof(int));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Rows.Add(new object[] { "A",2, DateTime.Parse("01-01-2000")});
                dt.Rows.Add(new object[] { "B",3, DateTime.Parse("01-01-2000")});
                dt.Rows.Add(new object[] { "A",4, DateTime.Parse("02-01-2000")});
                string[] uniqueUnits = dt.AsEnumerable().Select(x => x.Field<string>("unit")).Distinct().ToArray();
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("date", typeof(DateTime));
                foreach (string unit in uniqueUnits)
                {
                    dt1.Columns.Add(unit, typeof(int));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<DateTime>("date"));
                foreach (var group in groups)
                {
                    DataRow newRow = dt1.Rows.Add();
                    foreach (DataRow row in group)
                    {
                        newRow["date"] = group.Key;
                        newRow[row.Field<string>("unit")] = row.Field<int>("value");
                    }
                }
            }
        }
    }
