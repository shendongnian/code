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
                dt.Columns.Add("ItemName", typeof(string));
                dt.Columns.Add("ItemNo", typeof(int));
                dt.Columns.Add("ItemQty", typeof(int));
                dt.Columns.Add("GroupName", typeof(string));
                dt.Rows.Add(new object[] {"Pen",234, 2, "Group1"}); 
                dt.Rows.Add(new object[] {"Pen",234, 4, "Group2"}); 
                dt.Rows.Add(new object[] {"Pen",234, 6, "Group3"}); 
                dt.Rows.Add(new object[] {"Pen",234, 3, "Group4"}); 
                dt.Rows.Add(new object[] {"item2",365, 3, "Group1"}); 
                dt.Rows.Add(new object[] {"item2",365, 5, "Group2"}); 
                dt.Rows.Add(new object[] {"item2",365, 2, "Group3"}); 
                dt.Rows.Add(new object[] {"item2",365, 3, "Group4"});
                List<string> groupNames = dt.AsEnumerable().Select(x => x.Field<string>("GroupName")).Distinct().ToList();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("ItemName", typeof(string));
                pivot.Columns.Add("ItemNo", typeof(int));
                foreach (string groupName in groupNames)
                {
                    pivot.Columns.Add(groupName, typeof(string));
                }
                var items = dt.AsEnumerable().GroupBy(x => x.Field<string>("ItemName"));
                foreach (var item in items)
                {
                    DataRow pivotRow = pivot.Rows.Add();
                    pivotRow["ItemName"] = item.First().Field<string>("ItemName");
                    pivotRow["ItemNo"] = item.First().Field<int>("ItemNo");
                    foreach (var group in item)
                    {
                        pivotRow[group.Field<string>("GroupName")] = group.Field<int>("ItemQty");
                    }
                }
            }
        }
    }
