            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Marks", typeof(int));
            table.Rows.Add(new object[] { "A", 50 });
            table.Rows.Add(new object[] { "B", 100 });
            table.Rows.Add(new object[] { "C", 200 });
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (DataRow row in table.Rows)
            {
                dict.Add(row[0].ToString(), Convert.ToInt32(row[1].ToString()));
            }
            var arr = dict.ToArray();
