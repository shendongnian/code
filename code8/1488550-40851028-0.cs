    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("DateAndTime", typeof(DateTime));
                dt.Columns.Add("Column1", typeof(int));
                dt.Columns.Add("Column2", typeof(int));
                dt.Columns.Add("Column3", typeof(int));
                dt.Columns.Add("Column4", typeof(int));
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:00:10"), 1, 0, 0, 0 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:00:20"), 1, 0, 0, 1 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:00:30"), 1, 1, 0, 1 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:00:40"), 1, 1, 0, 0 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:00:50"), 0, 1, 0, 0 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:01:00"), 1, 0, 0, 1 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:01:10"), 1, 0, 0, 1 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:01:20"), 1, 0, 0, 0 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:01:30"), 0, 0, 0, 0 });
                dt.Rows.Add(new object[] { DateTime.Parse("2016-01-01 00:01:30"), 0, 0, 0, 0 });
                for (int colIndex = 1; colIndex <= dt.Columns.Count - 1; colIndex++)
                {
                    List<List<DateTime>> results = GetRanges("Column" + colIndex.ToString(), dt);
                    if (results != null)
                    {
                        Console.WriteLine("Column" + colIndex.ToString());
                        foreach (List<DateTime> result in results)
                        {
                            Console.WriteLine("From {0} To {1}", result[0].ToString(), result[1].ToString());
                        }
                    }
                }
                Console.ReadLine();
            }
            static List<List<DateTime>> GetRanges(string colName, DataTable dt)
            {
                List<List<DateTime>> results = new List<List<DateTime>>();
                List<DateTime> newResult = null;
                Boolean foundStart = false;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    int state = (int)row[colName];
                    if (!foundStart)
                    {
                        if (state == 1)
                        {
                            //add start time
                            newResult = new List<DateTime>();
                            results.Add(newResult);
                            //add date as both start and end incase there is only one item
                            newResult.Add((DateTime)row["DateAndTime"]);
                            newResult.Add((DateTime)row["DateAndTime"]);
                            foundStart = true;
                        }
                    }
                    else
                    {
                        if (state == 0)
                        {
                            foundStart = false;
                        }
                        else
                        {
                            newResult[1] = (DateTime)row["DateAndTime"];
                        }
                    }
                }
                if (results.Count == 0)
                    return null;
                else
                    return results;
            }
        }
    }
