    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication49
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("OPR_DT", typeof(DateTime));
                dt.Columns.Add("OPR_HR", typeof(int));
                dt.Columns.Add("ANC_TYPE", typeof(string));
                dt.Columns.Add("ANC_REGION", typeof(string));
                dt.Columns.Add("MARKET_RUN_ID", typeof(string));
                dt.Columns.Add("XML_DATE_ITEM", typeof(string));
                dt.Columns.Add("MW", typeof(decimal));
                dt.Columns.Add("GROUP", typeof(int));
                dt.Rows.Add(new object[] { DateTime.Parse("2/23/2017"), 1, "NR", "AS_CAISO_EXP", "DAM", "NS_CLR_PRC", 0.09, 1});
                dt.Rows.Add(new object[] { DateTime.Parse("2/23/2017"), 1, "RD", "AS_CAISO_EXP", "DAM", "RD_CLR_PRC", 2.83, 2 });
                dt.Rows.Add(new object[] { DateTime.Parse("2/23/2017"), 2, "NR", "AS_CAISO_EXP", "DAM", "NS_CLR_PRC", 0.01, 3 });
                dt.Rows.Add(new object[] { DateTime.Parse("2/23/2017"), 2, "RD", "AS_CAISO_EXP", "DAM", "RD_CLR_PRC", 0.1, 4 });
                string[] uniqueAncType = dt.AsEnumerable().Select(x => x.Field<string>("ANC_TYPE")).Distinct().ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("OPR_DT", typeof(DateTime));
                pivot.Columns.Add("OPR_HR", typeof(int));
                pivot.Columns.Add("ANC_REGION", typeof(string));
                pivot.Columns.Add("MARKET_RUN_ID", typeof(string));
                foreach (string col in uniqueAncType)
                {
                    pivot.Columns.Add(col, typeof(string));
                }
                var groups = dt.AsEnumerable()
                    .GroupBy(x => new {
                        opr_dt = x.Field<DateTime>("OPR_DT"),
                        opr_hr = x.Field<int>("OPR_HR"),
                        anc_region = x.Field<string>("ANC_REGION"),
                        run_id = x.Field<string>("MARKET_RUN_ID")
                    }).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow =  pivot.Rows.Add();
                    newRow["OPR_DT"] = group.Key.opr_dt;
                    newRow["OPR_HR"] = group.Key.opr_hr;
                    newRow["ANC_REGION"] = group.Key.anc_region;
                    newRow["MARKET_RUN_ID"] = group.Key.run_id;
                    foreach (DataRow ancType in group)
                    {
                        newRow[ancType.Field<string>("ANC_TYPE")] = ancType.Field<decimal>("MW");
                    }
                }
            }
        }
       
       
    }
