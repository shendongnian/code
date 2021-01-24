    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication68
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] arrn = {
                    "1;2017-04-03 06:29:10;first",
                    "1;2017-04-03 16:19:10;first",
                    "1;2017-04-03 06:49:10;first",
                    "1;2017-04-03 16:29:10;first",
                    "1;2017-04-03 17:06:04;second",
                    "1;2017-04-03 20:26:59;second",
                    "1;2017-04-03 17:27:41;second",
                    "1;2017-04-03 20:27:10;second",
                    "1;2017-04-03 21:07:41;third",
                    "1;2017-04-03 21:27:10;third",
                    "1;2017-04-03 23:27:41;third",
                    "1;2017-04-03 23:47:10;third",
                    "2;2017-04-03 14:56:04;first",
                    "2;2017-04-03 15:26:59;first",
                    "2;2017-04-03 15:27:41;first",
                    "2;2017-04-03 16:29:10;first",
                    "2;2017-04-04 14:56:04;first" 
                                };
                DataTable CheckFingerQty = new DataTable();
                CheckFingerQty.Columns.Add("IDp", typeof(int));
                CheckFingerQty.Columns.Add("Date", typeof(DateTime));
                CheckFingerQty.Columns.Add("Nobat", typeof(string));
                foreach (string arr in arrn)
                {
                    string[] a = arr.Split(';');
                    CheckFingerQty.Rows.Add(new object[] {
                        int.Parse(a[0]),
                        DateTime.Parse(a[1]).Date,
                        a[2]
                    });
                }
                var groups = CheckFingerQty.AsEnumerable()
                    .OrderBy(x => x.Field<DateTime>("Date"))
                    .GroupBy(x => x.Field<int>("IDp")).ToList();
                foreach (var group in groups)
                {
                    Console.WriteLine("IDP : '{0}'", group.Key.ToString());
                    foreach (var row in group)
                    {
                        Console.WriteLine("Date : '{0}'; Nobat : '{1}'", row.Field<DateTime>("Date").ToString(), row.Field<string>("Nobat"));
                    }
                }
                var idpDates = CheckFingerQty.AsEnumerable().GroupBy(x => new { date = x.Field<DateTime>("Date"), dp = x.Field<int>("IDp") }).ToList();
                foreach (var idpDate in idpDates)
                {
                    var noBatgroups = idpDate.GroupBy(x => x.Field<string>("Nobat")).ToList();
                    foreach (var noBatgroup in noBatgroups)
                    {
                        string noBatString = noBatgroup.Key + " is " + noBatgroup.Count().ToString();
                        Console.WriteLine("{0} {1} the count of {2}", idpDate.Key.dp, idpDate.Key.date.ToString("MM/dd/yyyy"), noBatString);
                    }
                }
                Console.ReadLine();
            }
        }
    }
