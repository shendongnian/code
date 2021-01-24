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
                    "1;04/03/2017 12:25:03;first",
                    "1;04/03/2017 12:25:03;first",
                    "1;04/03/2017 12:25:03;first",
                    "1;04/03/2017 12:25:03;first",
                    "1;04/03/2017 12:25:03;first",
                    "2;04/03/2017 12:25:03;first",
                    "2;04/03/2017 12:25:03;first",
                    "2;04/03/2017 12:25:03;first",
                    "2;04/03/2017 12:25:03;first",
                    "2;04/03/2017 12:25:03;first"
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
                        DateTime.Parse(a[1]),
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
                    var noBatgroup = idpDate.GroupBy(x => x.Field<string>("Nobat")).ToList();
                    string[] noBatString = noBatgroup.Select(x => x.Key + " is " + x.Count().ToString()).ToArray();
                    Console.WriteLine("{0} {1} the count of {2}", idpDate.Key.dp, idpDate.Key.date.ToString("MM/dd/yyyy"), string.Join(" and ", noBatString));
                }
                Console.ReadLine();
                    
            }
        }
     
    }
