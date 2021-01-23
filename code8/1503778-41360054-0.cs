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
                dt.Columns.Add("ColA", typeof(int));
                dt.Columns.Add("ColB", typeof(int));
                dt.Rows.Add(new object[] { 1,1,});
                dt.Rows.Add(new object[] { 1, 2, });
                dt.Rows.Add(new object[] { 2, 1, });
                dt.Rows.Add(new object[] { 2, 3, });
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<int>("ColA")).ToList();
                var results = groups.Select(x => x.Select(y => new { a = x.Key, b = y.Field<int>("ColB") }).ToList()).ToList();
     
            }
        }
    }
