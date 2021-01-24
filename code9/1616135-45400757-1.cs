    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IFormatProvider provider = CultureInfo.InvariantCulture;
                DataTable table = new DataTable();
                table.Columns.Add("Date", typeof(DateTime));
                table.Columns.Add("Status", typeof(string));
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 16:45", "dd-MM-yyyy HH:mm", provider), "Callback" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 16:48", "dd-MM-yyyy HH:mm", provider), "Callback" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 08:59", "dd-MM-yyyy HH:mm", provider), "Callback" });
                table.Rows.Add(new object[] { DateTime.ParseExact("28-07-2017 18:16", "dd-MM-yyyy HH:mm", provider), "Ingen Kontakt" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 09:00", "dd-MM-yyyy HH:mm", provider), "Callback" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 18:35", "dd-MM-yyyy HH:mm", provider), "Ja" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 17:43", "dd-MM-yyyy HH:mm", provider), "Callback" });
                table.Rows.Add(new object[] { DateTime.ParseExact("26-07-2017 19:33", "dd-MM-yyyy HH:mm", provider), "Ja" });
                table.Rows.Add(new object[] { DateTime.ParseExact("28-07-2017 18:16", "dd-MM-yyyy HH:mm", provider), "Ingen Kontakt" });
                table.Rows.Add(new object[] { DateTime.ParseExact("28-07-2017 18:16", "dd-MM-yyyy HH:mm", provider), "Optaget" });
                table.Rows.Add(new object[] { DateTime.ParseExact("28-07-2017 18:16", "dd-MM-yyyy HH:mm", provider), "Optaget" });
                string[] uniqueStatus = table.AsEnumerable().Select(x => x.Field<string>("Status")).Distinct().Where(x => x.Length > 0).ToArray();
                DataTable results = new DataTable();
                results.Columns.Add("Date", typeof(DateTime));
                foreach (string status in uniqueStatus)
                {
                    results.Columns.Add(status, typeof(int));
                }
                var groups = table.AsEnumerable().GroupBy(x => x.Field<DateTime>("Date").Date).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow = results.Rows.Add();
                    newRow["Date"] = group.Key;
                    var colGroups = group.GroupBy(x => x.Field<string>("Status")).ToList();
                    foreach (var colGroup in colGroups)
                    {
                        if (colGroup.Key.Length > 0)
                        {
                            newRow[colGroup.Key] = colGroup.Count();
                        }
                    }
                }
            }
        }
    }
