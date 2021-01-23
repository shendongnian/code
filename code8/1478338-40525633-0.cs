    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Day", typeof(DateTime));
                dt.Columns.Add("Group", typeof(int));
                dt.Columns.Add("Value", typeof(decimal));
                dt.Rows.Add(new object[] {1, DateTime.Parse("2016-10-11"), 1, 10.5});
                dt.Rows.Add(new object[] {2, DateTime.Parse("2016-10-11"), 1, 10.8});
                dt.Rows.Add(new object[] {3, DateTime.Parse("2016-10-11"), 2, 10.1});
                dt.Rows.Add(new object[] {4, DateTime.Parse("2016-10-11"), 2, 10.0});
                dt.Rows.Add(new object[] {5, DateTime.Parse("2016-10-12"), 1, 11.1});
                dt.Rows.Add(new object[] {6, DateTime.Parse("2016-10-12"), 1, 11.7});
                dt.Rows.Add(new object[] {7, DateTime.Parse("2016-10-12"), 2, 11.9});
                dt.Rows.Add(new object[] {8, DateTime.Parse("2016-10-12"), 2, 11.6});
                var results = dt.AsEnumerable()
                    .GroupBy(x => new { day = x.Field<DateTime>("Day"), group = x.Field<int>("Group")})
                    .Select(x => x.Select(y => y.Field<decimal>("Value")).OrderBy(z => z).ToList()).ToList();
            }
        }
    }
