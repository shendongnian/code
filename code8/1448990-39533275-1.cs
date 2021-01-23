    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable sourceTable = new DataTable();
                sourceTable.Columns.Add("Student", typeof(string));
                sourceTable.Columns.Add("Subject", typeof(string));
                sourceTable.Columns.Add("Mark", typeof(int));
                sourceTable.Rows.Add(new object[] { "Adam","English", 80});
                sourceTable.Rows.Add(new object[] { "Adam","Math", 70});
                sourceTable.Rows.Add(new object[] { "Adam","Science", 60});
                sourceTable.Rows.Add(new object[] { "Moses","English", 95});
                sourceTable.Rows.Add(new object[] { "Moses","Science", 75});
                List<string> subjects = sourceTable.AsEnumerable().Select(x => x.Field<string>("Subject")).Distinct().ToList();
                DataTable pivotTable = new DataTable();
                pivotTable.Columns.Add("Student", typeof(string));
                foreach(string subject in subjects)
                {
                    pivotTable.Columns.Add(subject, typeof(int));
                }
                var students = sourceTable.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Student")).ToList();
                foreach (var student in students)
                {
                    DataRow newRow = pivotTable.Rows.Add();
                    newRow["Student"] = student.Key;
                    foreach (DataRow row in student)
                    {
                        newRow[row.Field<string>("Subject")] = row.Field<int>("Mark"); 
                    }
                }
            }
        }
    }
