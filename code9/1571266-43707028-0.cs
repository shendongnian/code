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
                dt.Columns.Add("Gender", typeof(string));
                dt.Columns.Add("Disease", typeof(string));
                
                dt.Rows.Add(new object[] { "Male", "Anemia"});
                dt.Rows.Add(new object[] { "Female", "Anemia"});
                dt.Rows.Add(new object[] { "Male", "Anemia"});
                dt.Rows.Add(new object[] { "Female", "Anemia"});
                dt.Rows.Add(new object[] { "Male", "Anemia"});
                dt.Rows.Add(new object[] { "Male","Injuries" });
                dt.Rows.Add(new object[] { "Female", "Injuries" });
                dt.Rows.Add(new object[] { "Male", "Injuries" });
                dt.Rows.Add(new object[] { "Female", "Injuries" });
                string[] uniqueDieses = dt.AsEnumerable().Select(x => x.Field<string>("Disease")).Distinct().ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Disease", typeof(string));
                pivot.Columns.Add("Male", typeof(int));
                pivot.Columns.Add("Female", typeof(int));
                var groups = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Disease")).Select(x => new
                    {
                        disease = x.Key,
                        male = x.Where(y => y.Field<string>("Gender") == "Male").Count(),
                        female = x.Where(y => y.Field<string>("Gender") == "Female").Count()
                    }).ToList();
                foreach (var group in groups)
                {
                    pivot.Rows.Add(new object[] { group.disease, group.male, group.female });
                }
            }
        }
    }
