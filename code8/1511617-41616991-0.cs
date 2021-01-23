    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("doc_id", typeof(int));
                dt1.Columns.Add("customer_acc_no", typeof(string));
                dt1.Columns.Add("gcompany", typeof(string));
                dt1.Rows.Add(new object[] { 1, "100", "abc" });
                dt1.Rows.Add(new object[] { 2, "100", "def" });
                dt1.Rows.Add(new object[] { 3, "100", "def" });
                dt1.Rows.Add(new object[] { 4, "101", "abc" });
                dt1.Rows.Add(new object[] { 5, "101", "ghi" });
                dt1.Rows.Add(new object[] { 6, "102", "jkl" });
                dt1.Rows.Add(new object[] { 7, "102", "abc" });
                dt1.Rows.Add(new object[] { 8, "102", "def" });
                dt1.Rows.Add(new object[] { 9, "103", "abc" });
                dt1.Rows.Add(new object[] { 10, "103", "abc" });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("UserURN", typeof(int));
                dt2.Columns.Add("AccountNumber", typeof(string));
                dt2.Columns.Add("Company", typeof(string));
                dt2.Rows.Add(new object[] { 11, "100", "abc" });
                dt2.Rows.Add(new object[] { 12, "100", "def" });
                dt2.Rows.Add(new object[] { 13, "100", "def" });
                dt2.Rows.Add(new object[] { 14, "101", "abc" });
                dt2.Rows.Add(new object[] { 15, "101", "ghi" });
                dt2.Rows.Add(new object[] { 16, "102", "jkl" });
                dt2.Rows.Add(new object[] { 17, "102", "abc" });
                dt2.Rows.Add(new object[] { 18, "102", "def" });
                dt2.Rows.Add(new object[] { 19, "103", "abc" });
                dt2.Rows.Add(new object[] { 20, "103", "abc" });
                var results = from r1 in dt1.AsEnumerable()
                              join r2 in dt2.AsEnumerable() on
                                 new { x1 = r1.Field<string>("customer_acc_no"), x2 = r1.Field<string>("gcompany") } equals
                                 new { x1 = r2.Field<string>("AccountNumber"), x2 = r2.Field<string>("Company") }
                              select new { t1 = r1, t2 = r2 };
            }
        }
    }
