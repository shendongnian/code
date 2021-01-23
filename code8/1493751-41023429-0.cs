    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication31
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ActivationDate", typeof(DateTime));
                dt.Columns.Add("CurrentBranchDate", typeof(DateTime));
                dt.Columns.Add("AmountFinanced", typeof(decimal));
                dt.Columns.Add("Payments", typeof(decimal));
                dt.Columns.Add("CurrentBalance", typeof(decimal));
                dt.Rows.Add(new object[] { DateTime.Parse("1/1/16"), DateTime.Parse("1/30/16"), 10000, 100, 9800});
                dt.Rows.Add(new object[] { DateTime.Parse("1/1/16"), DateTime.Parse("2/29/16"), 10000, 0, 9900});
                dt.Rows.Add(new object[] { DateTime.Parse("1/1/16"), DateTime.Parse("3/31/16"), 10000, 2000, 7800});
                dt.Rows.Add(new object[] { DateTime.Parse("2/1/16"), DateTime.Parse("2/29/16"), 5000, 0, 5200});
                dt.Rows.Add(new object[] { DateTime.Parse("2/1/16"), DateTime.Parse("3/31/16"), 5000, 500, 4700});
                dt.Rows.Add(new object[] { DateTime.Parse("4/1/16"), DateTime.Parse("4/30/16"), 10000, 100, 9800});
                dt.Rows.Add(new object[] { DateTime.Parse("4/1/16"), DateTime.Parse("5/29/16"), 10000, 0, 9900});
                dt.Rows.Add(new object[] { DateTime.Parse("4/1/16"), DateTime.Parse("5/31/16"), 10000, 2000, 7800});
                dt.Rows.Add(new object[] { DateTime.Parse("5/1/16"), DateTime.Parse("4/29/16"), 5000, 0, 5200});
                dt.Rows.Add(new object[] { DateTime.Parse("5/1/16"), DateTime.Parse("5/31/16"), 5000, 500, 4700});
                dt.Rows.Add(new object[] { DateTime.Parse("7/1/16"), DateTime.Parse("7/30/16"), 10000, 100, 9800});
                dt.Rows.Add(new object[] { DateTime.Parse("7/1/16"), DateTime.Parse("8/29/16"), 10000, 0, 9900});
                dt.Rows.Add(new object[] { DateTime.Parse("7/1/16"), DateTime.Parse("8/31/16"), 10000, 2000, 7800});
                dt.Rows.Add(new object[] { DateTime.Parse("8/1/16"), DateTime.Parse("7/29/16"), 5000, 0, 5200});
                dt.Rows.Add(new object[] { DateTime.Parse("8/1/16"), DateTime.Parse("8/31/16"), 5000, 500, 4700});
                dt.Rows.Add(new object[] { DateTime.Parse("10/1/16"), DateTime.Parse("10/30/16"), 10000, 100, 9800});
                dt.Rows.Add(new object[] { DateTime.Parse("10/1/16"), DateTime.Parse("11/29/16"), 10000, 0, 9900});
                dt.Rows.Add(new object[] { DateTime.Parse("10/1/16"), DateTime.Parse("11/30/16"), 10000, 2000, 7800});
                dt.Rows.Add(new object[] { DateTime.Parse("11/1/16"), DateTime.Parse("10/29/16"), 5000, 0, 5200});
                dt.Rows.Add(new object[] { DateTime.Parse("11/1/16"), DateTime.Parse("11/30/16"), 5000, 500, 4700});
                var results = dt.AsEnumerable()
                    .GroupBy(x => (x.Field<DateTime>("ActivationDate").Month - 1) / 3)
                    .Select(x => new
                    {
                        Quarter = ((x.FirstOrDefault().Field<DateTime>("ActivationDate").Month - 1) / 3) + 1,
                        AmountFinanced = x.OrderByDescending(y => y.Field<DateTime>("CurrentBranchDate")).Select(y => y.Field<decimal>("AmountFinanced")).FirstOrDefault(),
                        CurrentBalance = x.OrderByDescending(y => y.Field<DateTime>("CurrentBranchDate")).Select(y => y.Field<decimal>("CurrentBalance")).FirstOrDefault(),
                        Sum_of_Payments = x.Sum(y => y.Field<decimal>("Payments"))
                    }).ToList();
            }
        }
    }
