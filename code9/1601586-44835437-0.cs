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
                MyClass myClass = new MyClass();
                myClass.Load();
                myClass.CreatePivotTable();
            }
        }
        class MyClass
        {
            public static List<MyClass> samples = new List<MyClass>();
            public DateTime dueDate { get; set; }
            public string desc { get; set; }
            public Decimal amount { get; set; }
            public static DataTable dt = new DataTable();
            public void Load()
            {
                samples = new List<MyClass>() {
                    new MyClass() { dueDate = DateTime.Parse("06-29-2015"), desc = "ABC", amount = 100},
                    new MyClass() { dueDate = DateTime.Parse("06-29-2015"), desc = "DEF", amount = 200},
                    new MyClass() { dueDate = DateTime.Parse("01-15-2015"), desc = "ABC", amount = 100},
                    new MyClass() { dueDate = DateTime.Parse("01-15-2015"), desc = "DEF", amount = 100}
                };
            }
            public void CreatePivotTable()
            {
                string[] uniqueDescription = samples.Select(x => x.desc).Distinct().ToArray();
                dt.Columns.Add("Due Date", typeof(DateTime));
                foreach (string desc in uniqueDescription)
                {
                    dt.Columns.Add(desc, typeof(decimal));
                }
                var groups = samples.GroupBy(x => x.dueDate);
                foreach(var group in groups)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["Due Date"] = group.Key;
                    foreach (string col in uniqueDescription)
                    {
                        newRow[col] = group.Where(x => x.desc == col).Sum(x => x.amount);
                    }
                }
            }
        }
    }
