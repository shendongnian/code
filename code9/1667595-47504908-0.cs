                DataTable dt = new DataTable();
                dt.Columns.Add("Label", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                dt.Rows.Add(new object[] { "Namelabel", "texttoenter123" });
                dt.Rows.Add(new object[] { "Email", "test@test.com" });
                Dictionary<string, string> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Label"), y => y.Field<string>("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
