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
                dt.Columns.Add("Systime", typeof(DateTime));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                dt.Rows.Add(new object[] { DateTime.Parse("01/04/2017"),"Water", 12});
                dt.Rows.Add(new object[] { DateTime.Parse("01/04/2017"),"Bread", 14});
                dt.Rows.Add(new object[] { DateTime.Parse("01/04/2017"),"Chair", 11});
                dt.Rows.Add(new object[] { DateTime.Parse("02/04/2017"),"Water", 25});
                dt.Rows.Add(new object[] { DateTime.Parse("02/04/2017"),"Bread", 16});
                dt.Rows.Add(new object[] { DateTime.Parse("02/04/2017"),"Chair", 21});
                string[] items = dt.AsEnumerable().Select(x => x.Field<string>("Name")).Distinct().ToArray();
                DataTable pivot = new DataTable();
                foreach(string item in items)
                {
                    pivot.Columns.Add(item, typeof(int));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<DateTime>("Systime")).ToList();
                int index = 0;
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    foreach (string item in items)
                    {
                        newRow[item] = group.Where(x => x.Field<string>("Name") == item).Select(x => x.Field<int>("Value")).Sum();
                    }
                }
            }
        }
        
    }
