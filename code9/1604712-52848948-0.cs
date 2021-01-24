        public DataTable ListToDataTable(IList list)
        {
            var dt = new DataTable();
            if (list.Count <= 0) return dt;
            var properties = list[0].GetType().GetProperties();
            foreach (var pi in properties)
            {
                dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
            }
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                properties.ToList().ForEach(p => row[p.Name] = p.GetValue(item, null) ?? DBNull.Value);
                dt.Rows.Add(row);
            }
            return dt;
        }
