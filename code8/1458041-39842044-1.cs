    using (DataTable dt = new DataTable("Test"))
            {
                dt.Columns.Add(new DataColumn("id", typeof(int)));
                dt.Columns.Add(new DataColumn("value", typeof(double)));
                dt.Columns.Add(new DataColumn("dated", typeof(DateTime)));
                dt.Rows.Add(new Object[] { 1, 2.3, DateTime.Now });
                Console.WriteLine(dt.ToCSV("{0}|\"{1}\"|{2:d}", "{0}|{1}|{2}"));
                Console.ReadKey();
            }
