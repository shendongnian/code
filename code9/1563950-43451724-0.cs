    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication49
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Urld", typeof(int));
                dt.Columns.Add("Typeid", typeof(int));
                dt.Columns.Add("DomainId", typeof(int));
                dt.Rows.Add(new object[] { 13, 1, 79 });
                dt.Rows.Add(new object[] { 14, 2, 79 });
                dt.Rows.Add(new object[] { 15, 2, 81 });
                dt.Rows.Add(new object[] { 16, 1, 81 });
                var results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("DomainID"))
                    .ToDictionary(x => x.Key, y => y.Count());
            }
        }
    }
