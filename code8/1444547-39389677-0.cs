    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                string[] inputs = { 
                    "1 | 2016/09/08 14:02:08 | NY",
                    "1 | 2016/09/08 14:03:08 | CA",
                    "1 | 2016/09/08 14:05:08 | SI",
                    "1 | 2016/09/08 14:07:05 | NY",
                    "1 | 2016/09/08 14:07:09 | NY",
                    "1 | 2016/09/08 14:07:22 | NY",
                    "1 | 2016/09/08 14:09:08 | SI",
                    "1 | 2016/09/08 14:23:08 | NY",
                    "1 | 2016/09/08 14:25:08 | LA"
                                 };
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Columns.Add("location", typeof(string));
                foreach (string input in inputs)
                {
                    string[] splitRow = input.Split(new char[] {'|'});
                    dt.Rows.Add( new object[] {
                        int.Parse(splitRow[0]),
                        DateTime.Parse(splitRow[1]),
                        splitRow[2].Trim()
                    });
                }
                var groups = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("location"))
                    .Select(x => new {
                        id = x.First().Field<int>("Id"),
                        location = x.First().Field<string>("location"),
                        times = x.Select(y => y.Field<DateTime>("date")).ToList()
                    }).ToList();
                foreach (var group in groups)
                {
                    DateTime lastTime = new DateTime();
                    foreach (var date in group.times)
                    {
                        if (lastTime.AddMinutes(5) <= date)
                        {
                            Console.WriteLine(string.Join(",",  new string[] { group.id.ToString(), group.location, date.ToString()}));
                            lastTime = date;
                        }
                        
                    }
                }
                Console.ReadLine();
            }
     
        }
    }
