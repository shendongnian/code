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
                dt.Columns.Add("time", typeof(DateTime));
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 0, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 5, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 20, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 25, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 30, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 40, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 45, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 50, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 56, 0) });
                dt.Rows.Add(new object[] { new DateTime(2017, 1, 1, 1, 58, 0) });
                List<DateTime> times = dt.AsEnumerable().Where((x, i) => (i > 0) && (x.Field<DateTime>("time") - dt.Rows[i - 1].Field<DateTime>("time")).TotalMinutes < 10).Select(x => x.Field<DateTime>("time")).ToList();
            }
        }
    }
