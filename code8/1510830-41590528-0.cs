    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("key", typeof(string));
                dt.Columns.Add("val", typeof(string));
                dt.Rows.Add(new object[] {"aaa","1"});
                dt.Rows.Add(new object[] {"aaa","2"});
                dt.Rows.Add(new object[] {"aaa","3"});
                dt.Rows.Add(new object[] {"bbb","x"});
                dt.Rows.Add(new object[] {"bbb","y"});
                dt.Rows.Add(new object[] {"bbb","z"});
                dt.Rows.Add(new object[] {"ccc","on"});
                dt.Rows.Add(new object[] {"ccc","off"});
                Data.data = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("key"))
                    .Select(x => new Data()
                    {
                        key = x.Key,
                        values = x.Select(y => y.Field<string>("val")).ToList()
                    }).ToList();
                Data.Print(0, new List<string>());
                Console.ReadLine();
            }
        }
        public class Data
        {
            public static List<Data> data = null;
            public string key { get; set; }
            public List<string> values { get; set; }
            public static void Print(int level, List<string> output)
            {
                if (level == data.Count)
                {
                    Console.WriteLine(string.Join(" | ", output));
                }
                else
                {
                    foreach(string _value in data[level].values)
                    {
                        List<string> newOutput = new List<string>();
                        newOutput.AddRange(output);
                        newOutput.Add(data[level].key);
                        newOutput.Add(_value);
                        Print(level + 1, newOutput);
                    }
                }
            }
        }
    }
