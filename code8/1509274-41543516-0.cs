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
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ID", typeof(int));
                dt1.Columns.Add("Subject", typeof(string));
                dt1.Columns.Add("Description", typeof(string));
                dt1.Rows.Add(new object[] { 123, "Test", "Test" });
                dt1.Rows.Add(new object[] { 234, "Test", "Test" });
                dt1.Rows.Add(new object[] { 456, "Test 1", "Test1" });
                dt1.Rows.Add(new object[] { 789, "Test 1", "Test1" });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                dt2.Columns.Add("Subject", typeof(string));
                dt2.Columns.Add("Description", typeof(string));
                dt2 = dt1.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Subject"))
                    .Select(x => dt2.Rows.Add(new object[] {
                            string.Join(",", x.Select(y => y.Field<int>("ID").ToString()).ToArray()),
                            x.Key,
                            x.FirstOrDefault().Field<string>("Description")
                        })).CopyToDataTable();
            }
        }
    }
