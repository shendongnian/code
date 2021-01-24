            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("hello", typeof(int)));
            tbl.Columns.Add(new DataColumn("world", typeof(string)));
            DataRow newRow = tbl.NewRow();
            newRow["hello"] = 1;
            newRow["world"] = "boobies";
            tbl.Rows.Add(newRow);
            foreach (DataRow row in tbl.Rows)
            {
                var expando = new ExpandoObject() as IDictionary<string, Object>;
                foreach (DataColumn col in tbl.Columns)
                {
                    expando.Add(col.ColumnName, row[col.ColumnName]);
                }
            }
