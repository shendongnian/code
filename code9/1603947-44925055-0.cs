    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication64
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("a", typeof(int));
                dt.Columns.Add("b", typeof(string));
                dt.Columns.Add("c", typeof(string));
                dt.Columns.Add("d", typeof(string));
                dt.Rows.Add(new object[] { 1, "b1", "c", "d" });
                dt.Rows.Add(new object[] { 2, "b1", "c", "d" });
                dt.Rows.Add(new object[] { 3, "b1", "c", "d" });
                dt.Rows.Add(new object[] { 4, "b2", "c", "d" });
                dt.Rows.Add(new object[] { 5, "b2", "c", "d" });
                dt.Rows.Add(new object[] { 6, "b3", "c", "d" });
                dt.Rows.Add(new object[] { 7, "b4", "c", "d" });
                var results = dt.AsEnumerable().GroupBy(x => x.Field<string>("b")).Select(x => new { key = x.Key, sum = x.Sum(y => y.Field<int>("a"))}).ToList();
            }
        }
    }
