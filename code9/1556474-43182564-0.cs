                DataTable dt = new DataTable();
                dt.Columns.Add("Date",typeof(DateTime));
                dt.Columns.Add("Code",typeof(int));
                dt.Rows.Add(new object[] { DateTime.Parse("04/03/2017"), 1234});
                dt.Rows.Add(new object[] { DateTime.Parse("03/31/2017"), 1234});
                dt.Rows.Add(new object[] { DateTime.Parse("03/29/2017"), 1234});
                dt.Rows.Add(new object[] { DateTime.Parse("03/29/2017"), 4321});
                dt.Rows.Add(new object[] { DateTime.Parse("03/25/2017"), 4321});
                var groups = dt.AsEnumerable().GroupBy(x => (int)(x.Field<DateTime>("Date").DayOfYear + (int)new DateTime(x.Field<DateTime>("Date").Year, 1, 1).DayOfWeek)/7).ToList();
