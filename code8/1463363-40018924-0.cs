    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication16
    {
        class Program
        {
             static void Main(string[] args)
            {
                 DataTable dt = new DataTable();
                 dt.Columns.Add("PillarId", typeof(int));
                 dt.Columns.Add("Quarter", typeof(string));
                 dt.Columns.Add("Feature", typeof(string));
                 dt.Rows.Add(new object[] {1, "Q12116", "France"});
                 dt.Rows.Add(new object[] {1, "Q12116", "Germany"});
                 dt.Rows.Add(new object[] {1, "Q22116", "Italy"});
                 dt.Rows.Add(new object[] {1, "Q32116", "Russia"});
                 dt.Rows.Add(new object[] {2, "Q22116", "India"});
                 dt.Rows.Add(new object[] {2, "Q32116", "USA"});
                 dt.Rows.Add(new object[] {3, "Q22116", "China"});
                 dt.Rows.Add(new object[] {3, "Q32116", "Austrailia"});
                 dt.Rows.Add(new object[] {3, "Q32116", "New Zeland"});
                 dt.Rows.Add(new object[] {3, "Q42116", "Japan"});
                 string[] uniqueQuarters = dt.AsEnumerable().Select(x => x.Field<string>("Quarter")).Distinct().ToArray();
                 var groups = dt.AsEnumerable()
                     .GroupBy(x => x.Field<int>("PillarId")).Select(x => x.GroupBy(y => y.Field<string>("Quarter")).Select(z => new { id = x.Key, quarter = z.Key, feature = z.Select((a,i) => new { feature = a.Field<string>("Feature"), index = i}).ToList()}).ToList()).ToList();
                 DataTable pivot = new DataTable();
                 pivot.Columns.Add("PillarId", typeof(int));
                 foreach (string quarter in uniqueQuarters)
                 {
                     pivot.Columns.Add(quarter, typeof(string));
                 }
                 foreach (var group in groups)
                 {
                     int maxNewRows = group.Select(x => x.feature.Count()).Max();
                     for (int index = 0; index < maxNewRows; index++)
                     {
                         DataRow newRow = pivot.Rows.Add();
                         foreach (var row in group)
                         {
                             newRow["PillarId"] = row.id;
                             newRow[row.quarter] = row.feature.Skip(index) == null || !row.feature.Skip(index).Any() ? "" : row.feature.Skip(index).First().feature;
                         }
                     }
                 }
            }
        }
     
    }
