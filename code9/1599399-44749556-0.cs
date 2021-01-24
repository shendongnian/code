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
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Label", typeof(string));
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("Amount", typeof(int));
                dt.Columns.Add("Category", typeof(int));
                dt.Columns.Add("OriginDate", typeof(DateTime));
                dt.Rows.Add(new object[] { 1,"Foo",1,100,8, DateTime.Parse("2017-01-23")});
                dt.Rows.Add(new object[] { 2,"Bar",2,250,1, DateTime.Parse("2017-01-30")});
                dt.Rows.Add(new object[] { 3,"Foo",1,400,12, DateTime.Parse("2017-02-15")});
                var results = dt.AsEnumerable().GroupBy(x => new { month = x.Field<DateTime>("OriginDate").Month, year = x.Field<DateTime>("OriginDate").Year }).Select(x => new {
                    month = x.Key.month,
                    year = x.Key.year,
                    amount = x.Select(y => y.Field<int>("Amount")).Sum()
                }).ToList();
            }
        }
    }
