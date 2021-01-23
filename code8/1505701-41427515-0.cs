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
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Family", typeof(string));
                dt.Columns.Add("R", typeof(string));
                dt.Columns.Add("C", typeof(int));
                dt.Columns.Add("D", typeof(string));
                dt.Rows.Add(new object[] {"N1","F1","S1", 1, "A"});
                dt.Rows.Add(new object[] {"N2","F2","S2", 2, "A"});
                dt.Rows.Add(new object[] {"N3","F3","S1", 1, "B"});
                dt.Rows.Add(new object[] {"N4","F4","S2", 2, "B"});
                dt.Rows.Add(new object[] {"N5","F5","S3", 3, "A"});
                string[] uniqueRs = dt.AsEnumerable().Select(x => x.Field<string>("R")).Distinct().OrderBy(x => x).ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("D", typeof(string));
                foreach (string uniqueR in uniqueRs)
                {
                    pivot.Columns.Add(uniqueR, typeof(string));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("D"));
                foreach (var group in groups)
                {
                    List<string> names = group.OrderBy(x => x.Field<int>("C")).Select(x => x.Field<string>("Name")).ToList();
                    names.Insert(0, group.Key);
                    pivot.Rows.Add(names.ToArray());
                    List<string> families = group.OrderBy(x => x.Field<int>("C")).Select(x => x.Field<string>("Family")).ToList();
                    families.Insert(0, group.Key);
                    pivot.Rows.Add(families.ToArray());
                }
            }
        }
    }
