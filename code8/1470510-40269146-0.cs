        static DataTable DictionaryToDataTable(Dictionary<string,Dictionary<string,string>> dictionary)
        {
            int index;
            string key = "YourPrimaryKeyColumnNameHere";
            DataTable dt = new DataTable();
            dt.Columns.Add(key);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[key] };
            foreach (var header in dictionary)
            {
                dt.Columns.Add(header.Key);
                foreach (var row in header.Value)
                {
                    index = dt.Rows.IndexOf(dt.Rows.Find(row.Key));
                    if (index < 0)
                    {
                        dt.Rows.Add(new[] { row.Key });
                        dt.Rows[dt.Rows.Count - 1][header.Key] = row.Value;
                    }
                    else
                    {
                        dt.Rows[index][header.Key] = row.Value;
                    }
                }
            }
            return dt;
        }
