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
                dt.Rows.Add(new object[] { DateTime.Parse("11/01/2016"), DateTime.Parse("11/30/2017"), 57000, 0, 53639.4 });
                dt.Rows.Add(new object[] { DateTime.Parse("01/01/2017"), DateTime.Parse("11/30/2017"), 52000, 0, 52000 });
                dt.Rows.Add(new object[] { DateTime.Parse("03/01/2017"), DateTime.Parse("11/30/2017"), 28000, 0, 27160.82 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("04/30/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("05/31/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("06/30/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("06/30/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("07/31/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("08/31/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("09/30/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("07/31/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("08/31/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("09/30/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("10/31/2017"), 77200, 0, 76190.96 });
                dt.Rows.Add(new object[] { DateTime.Parse("04/01/2017"), DateTime.Parse("11/30/2017"), 77200, -1947.7, 74616.01 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("10/31/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("06/01/2017"), DateTime.Parse("11/30/2017"), 98450, 0, 98450 });
                dt.Rows.Add(new object[] { DateTime.Parse("08/01/2017"), DateTime.Parse("08/31/2017"), 20000, 0, 20000 });
                dt.Rows.Add(new object[] { DateTime.Parse("08/01/2017"), DateTime.Parse("09/30/2017"), 20000, 0, 20000 });
                dt.Rows.Add(new object[] { DateTime.Parse("08/01/2017"), DateTime.Parse("10/31/2017"), 20000, -1631.58, 18540.78 });
                dt.Rows.Add(new object[] { DateTime.Parse("08/01/2017"), DateTime.Parse("11/30/2017"), 20000, 0, 18540.78 });
                dt.Rows.Add(new object[] { DateTime.Parse("10/01/2017"), DateTime.Parse("10/31/2017"), 25000, -509.55, 24490.45 });
                dt.Rows.Add(new object[] { DateTime.Parse("10/01/2017"), DateTime.Parse("11/30/2017"), 25000, 0, 24490.45 });
                var quarterResults = dt.AsEnumerable()
                        .GroupBy(x => new { ActivationQuarter = (x.Field<DateTime>("ActivationDate").Month - 1) / 3, ActivationYear = x.Field<DateTime>("ActivationDate").Year })
                        .Select(x => new {
                            activationYear = x.FirstOrDefault().Field<DateTime>("ActivationDate").Year,
                            quarterResults = ((x.FirstOrDefault().Field<DateTime>("ActivationDate").Month - 1) / 3) + 1,
                            branchYear = x.FirstOrDefault().Field<DateTime>("CurrentBranchDate").Year,
                            branchQuarter = ((x.FirstOrDefault().Field<DateTime>("CurrentBranchDate").Month - 1) / 3) + 1,
                            AmountFinanced = x.GroupBy(y => new { ActivationDate = y.Field<DateTime>("ActivationDate")}).Select(z => z.OrderByDescending(a => a.Field<DateTime>("CurrentBranchDate")).Select(y => y.Field<decimal>("AmountFinanced")).FirstOrDefault()).Sum(),
                            CurrentBalance = x.OrderByDescending(y => y.Field<DateTime>("CurrentBranchDate")).Select(y => y.Field<decimal>("CurrentBalance")).FirstOrDefault(),
                            sum = x.Select(y => y.Field<decimal?>("Payments")).Sum()
                        }).ToArray();
            }
        }
     
    }
