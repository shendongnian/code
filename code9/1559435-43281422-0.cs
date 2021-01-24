    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication49
    {   
        class Program
        {
            
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Amount", typeof(int));
                dt.Rows.Add(new object[] {1, "A", 10});
                dt.Rows.Add(new object[] {1, "B", 5});
                dt.Rows.Add(new object[] {2, "A", 14});
                dt.Rows.Add(new object[] {2, "B", 7});
                dt.Rows.Add(new object[] {3, "A", 2});
                dt.Rows.Add(new object[] {3, "B", 8});
                string[] uniqueTypes = dt.AsEnumerable().Select(x => x.Field<string>("Type")).Distinct().ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("ID", typeof(int));
                foreach (string _type in uniqueTypes)
                {
                    pivot.Columns.Add(_type, typeof(int));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<int>("ID")).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["ID"] = group.Key;
                    foreach (DataRow row in group)
                    {
                        newRow[row.Field<string>("Type")] = row.Field<int>("Amount");
                    }
                }
            }
        } 
    }
