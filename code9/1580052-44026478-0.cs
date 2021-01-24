    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication55
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof (DateTime));
                dt.Columns.Add("Name", typeof (string));
                dt.Columns.Add("Id", typeof (int));
                dt.Columns.Add("Item", typeof (string));
                dt.Rows.Add(new object[] { DateTime.Parse("23-March-2017"), "Vinod", 1, "USB"});
                dt.Rows.Add(new object[] { DateTime.Parse("02-May-2017"), "Sureka", 2, "Cable"});
                dt.Rows.Add(new object[] { DateTime.Parse("23-March-2017"), "Mahesh",6, "Mouse"});
                dt.Rows.Add(new object[] { DateTime.Parse("24-May-2017"), "Raju",7, "Keyboard"});
                dt.Rows.Add(new object[] { DateTime.Parse("09-May-2017"), "Raju", 2, "Cable"});
                dt.Rows.Add(new object[] { DateTime.Parse("23-March-2017"), "Mahesh", 6, "Mouse"});
                dt.Rows.Add(new object[] { DateTime.Parse("02-May-2017"), "Ganga", 7, "Keyboard"});
                Dictionary<DateTime, List<string>> dict = dt.AsEnumerable().GroupBy(x => x.Field<DateTime>("Date")).ToDictionary(x => x.Key, y => y.Select(z => z.Field<string>("Name") + "-" + z.Field<string>("Item")).ToList());
            }
      
        }
    }
