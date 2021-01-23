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
                dt.Columns.Add("OldDate", typeof(long));
                dt.Columns.Add("ColA", typeof(string));
                dt.Columns.Add("ColB", typeof(string));
                dt.Columns.Add("ColC", typeof(string));
                dt.Rows.Add(new object[] { 636038375869883449, "b", "b", "b" });
                dt.Rows.Add(new object[] { 636038375869883450, "b", "b", "b" });
                dt.Rows.Add(new object[] { 636038375869883451, "b", "b", "b" });
                dt.Rows.Add(new object[] { 636038375869883452, "b", "b", "b" });
                dt.Rows.Add(new object[] { 636038375869883453, "b", "b", "b" });
                dt.Columns.Add("NewDate", typeof(DateTime));
                foreach (DataRow row in dt.AsEnumerable())
                {
                    row["NewDate"] = DateTime.FromBinary(row.Field<long>("OldDate"));
                }
                dt.Columns.Remove("OldDate");
                dt.Columns["NewDate"].SetOrdinal(0);
            }
        }
    }
