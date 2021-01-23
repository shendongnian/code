            DataTable dt1 = new DataTable();
            dt1.Columns.Add(new DataColumn("unit",typeof(string)));
            dt1.Columns.Add(new DataColumn("value",typeof(int)));
            dt1.Columns.Add(new DataColumn("date",typeof(DateTime)));
            dt1.Rows.Add(new object[] { "A", 2, DateTime.Parse("01-01-2000") });
            dt1.Rows.Add(new object[] { "B", 3, DateTime.Parse("01-01-2000") });
            dt1.Rows.Add(new object[] { "A", 4, DateTime.Parse("02-01-2000") });
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("date", typeof(DateTime)));
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["date"], };
            List<string> cols = new List<string>();
            List<DateTime> ds = new List<DateTime>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                string unit = dr1["unit"].ToString();
                if (!cols.Contains(unit))
                {
                    dt2.Columns.Add(new DataColumn(unit, typeof(int)));
                    cols.Add(unit);
                }
                DateTime pkDate = (DateTime)dr1["date"];
                if (!ds.Contains(pkDate))
                {
                    ds.Add(pkDate);
                    DataRow dr = dt2.NewRow();
                    dr["date"] = dr1["date"];
                    dr[unit] = dr1["value"];
                    dt2.Rows.Add(dr);
                }
                else
                {
                    dt2.Rows.Find(pkDate)[unit] = dr1["value"];
                }
            }
