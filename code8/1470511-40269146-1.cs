        static DataTable DictionaryToDataTable(Dictionary<string,Dictionary<string,string>> dictionary)
        {
            int index;
            string key = "YourPrimaryKeyColumnNameHere";
            DataTable dt = new DataTable();
            // Setting primary key allows you to perform Find() and IndexOf() later on
            dt.Columns.Add(key);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[key] };
            foreach (var header in dictionary)
            {
                dt.Columns.Add(header.Key);
                foreach (var row in header.Value)
                {
                    index = dt.Rows.IndexOf(dt.Rows.Find(row.Key));
                    // Index will be -1 if the row isn't found, ie on the first iteration
                    if (index < 0)
                    {
                        // When creating a new row, start it with the unique primary key field
                        dt.Rows.Add(new[] { row.Key });
                        // We use dt.Rows.Count - 1 to get the last (newly added) row
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
