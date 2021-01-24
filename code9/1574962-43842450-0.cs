            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("appointment_type", typeof(string));
                dt.Columns.Add("appointment_date", typeof(DateTime));
                dt.Rows.Add(new object[] { "Ali", "dental", DateTime.Parse("8/5/2017 08:00:00")});
                dt.Rows.Add(new object[] { "Ali", "dental", DateTime.Parse("8/5/2017 16:00:00")});
                var groups = dt.AsEnumerable().GroupBy(x => new { name = x.Field<string>("name"), type = x.Field<string>("appointment_type") }).ToList();
                dt = groups.Select(x => x.OrderBy(y => y.Field<DateTime>("appointment_date")).LastOrDefault()).CopyToDataTable();
            }
