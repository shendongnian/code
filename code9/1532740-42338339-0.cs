            Dictionary<string, string> vals = new Dictionary<string, string>();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    vals.Add(dt.Columns[i].ColumnName, dr[dt.Columns[i].ColumnName].ToString());
                }
            }
