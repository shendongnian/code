    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Day", typeof(DateTime));
                dt.Columns.Add("Group", typeof(int));
                dt.Columns.Add("Value", typeof(decimal));
                dt.Rows.Add(new object[] {1 , DateTime.Parse("2016-10-11"), 1, 10.5});
                dt.Rows.Add(new object[] {2 , DateTime.Parse("2016-10-11"), 1, 10.8});
                dt.Rows.Add(new object[] {3 , DateTime.Parse("2016-10-11"), 1, 10.7});
                dt.Rows.Add(new object[] {4 , DateTime.Parse("2016-10-11"), 1, 10.6});
                dt.Rows.Add(new object[] {5 , DateTime.Parse("2016-10-11"), 1, 10.5});
                dt.Rows.Add(new object[] {6 , DateTime.Parse("2016-10-11"), 1, 10.4});
                dt.Rows.Add(new object[] {7 , DateTime.Parse("2016-10-11"), 1, 10.8});
                dt.Rows.Add(new object[] {8 , DateTime.Parse("2016-10-11"), 1, 10.2});
                dt.Rows.Add(new object[] {9 , DateTime.Parse("2016-10-11"), 1, 10.0});
                dt.Rows.Add(new object[] {10, DateTime.Parse("2016-10-11"), 1, 10.9});
                dt.Rows.Add(new object[] {11, DateTime.Parse("2016-10-11"), 2, 10.1});
                dt.Rows.Add(new object[] {12, DateTime.Parse("2016-10-11"), 2, 10.0});
                dt.Rows.Add(new object[] {13, DateTime.Parse("2016-10-11"), 2, 10.1});
                dt.Rows.Add(new object[] {14, DateTime.Parse("2016-10-11"), 2, 10.6});
                dt.Rows.Add(new object[] {15, DateTime.Parse("2016-10-11"), 2, 10.7});
                dt.Rows.Add(new object[] {16, DateTime.Parse("2016-10-11"), 2, 10.2});
                dt.Rows.Add(new object[] {17, DateTime.Parse("2016-10-11"), 2, 10.0});
                dt.Rows.Add(new object[] {18, DateTime.Parse("2016-10-11"), 2, 10.5});
                dt.Rows.Add(new object[] {19, DateTime.Parse("2016-10-11"), 2, 10.5});
                dt.Rows.Add(new object[] {20, DateTime.Parse("2016-10-11"), 2, 10.8});
                dt.Rows.Add(new object[] {21, DateTime.Parse("2016-10-12"), 1, 11.1});
                dt.Rows.Add(new object[] {22, DateTime.Parse("2016-10-12"), 1, 11.7});
                dt.Rows.Add(new object[] {23, DateTime.Parse("2016-10-12"), 1, 11.0});
                dt.Rows.Add(new object[] {24, DateTime.Parse("2016-10-12"), 1, 11.4});
                dt.Rows.Add(new object[] {25, DateTime.Parse("2016-10-12"), 1, 11.7});
                dt.Rows.Add(new object[] {26, DateTime.Parse("2016-10-12"), 1, 11.8});
                dt.Rows.Add(new object[] {27, DateTime.Parse("2016-10-12"), 1, 11.1});
                dt.Rows.Add(new object[] {28, DateTime.Parse("2016-10-12"), 1, 11.1});
                dt.Rows.Add(new object[] {29, DateTime.Parse("2016-10-12"), 1, 11.4});
                dt.Rows.Add(new object[] {30, DateTime.Parse("2016-10-12"), 1, 11.6});
                dt.Rows.Add(new object[] {31, DateTime.Parse("2016-10-12"), 2, 11.9});
                dt.Rows.Add(new object[] {32, DateTime.Parse("2016-10-12"), 2, 11.6});
                var results = dt.AsEnumerable()
                    .GroupBy(x => new { day = x.Field<DateTime>("Day"), group = x.Field<int>("Group")})
                    .Select(x => x.Select(y => y.Field<decimal>("Value")).OrderBy(z => z).ToList()).ToList();
                List<List<decimal>> groups = new List<List<decimal>>();
                const int NUM_GROUPS = 2;
                foreach (var result in results)
                {
                    int size = result.Count;
                    int groupSize = (int)(size / NUM_GROUPS); //round down
     
                    List<decimal> newGroup = new List<decimal>() { result[0] };
                    groups.Add(newGroup);
                    for (int groupNum = 0; groupNum < NUM_GROUPS; groupNum++)
                    {
                        newGroup.Add( result.Skip(groupNum * groupSize).Take(groupSize).Max());
                    }
                }
            }
        }
    }
