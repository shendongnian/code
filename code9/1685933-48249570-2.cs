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
                RecomData recomData = new RecomData();
                List<RecomData> data = new List<RecomData>();
                recomData.objToDataTable(data, true);
            }
        }
        public class RecomData
        {
            public int UserID { get; set; }
            public string Gender { get; set; }
            public DateTime DateTo { get; set; }
            public DateTime DateFrom { get; set; }
            public string Relegion { get; set; }
            public int Age { get; set; }
            public int DailyHrs { get; set; }
            public string OtherServices { get; set; }
            public string Comments { get; set; }
            public string[] TasksArr { get; set; }
            DataTable dt = null;
            public DataTable objToDataTable(List<RecomData> obj, Boolean createTable)
            {
                int maxTaskArr = obj.Max(x => x.TasksArr.Length);
                if (createTable)
                {
                    dt = new DataTable("OutputData");
                    DataRow dr = dt.NewRow();
                    dt.Columns.Add("Gender", typeof(string));
                    dt.Columns.Add("DateTo", typeof(DateTime));
                    dt.Columns.Add("DateFrom", typeof(DateTime));
                    dt.Columns.Add("Religion", typeof(string));
                    dt.Columns.Add("Age", typeof(int));
                    dt.Columns.Add("DailyHrs", typeof(int));
                    dt.Columns.Add("OtherServices", typeof(string));
                    dt.Columns.Add("Comments", typeof(string));
                    for (int i = 0; i < maxTaskArr; i++)
                    {
                        dt.Columns.Add("Task_" + i.ToString(), typeof(string));
                    }
                }
                else
                {
                    int numberTasks = dt.Columns.Cast<DataColumn>().Where(x => x.ColumnName.StartsWith("Task_")).Count();
                    for (int i = numberTasks; i < maxTaskArr; i++)
                    {
                        dt.Columns.Add("Task_" + i.ToString(), typeof(string));
                    }
                }
                foreach (RecomData recomData in obj)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["Gender"] = recomData.Gender;
                    newRow["DateTo"] = recomData.DateTo;
                    newRow["DateFrom"] = recomData.DateFrom;
                    newRow["Religion"] = recomData.Relegion;
                    newRow["Age"] = recomData.Age;
                    newRow["DailyHrs"] = recomData.DailyHrs;
                    newRow["OtherServices"] = recomData.OtherServices;
                    int index = 0;
                    foreach (string task in recomData.TasksArr)
                    {
                        newRow["Task_" + index.ToString()] = task;
                    }
                }
                return dt;
            }
        }
    }
