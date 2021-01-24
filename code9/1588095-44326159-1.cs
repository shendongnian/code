          var temp = (from p in Data2.AsEnumerable()
                              group p by new
                              {
                                  ID = p.Field<string>("ID"),
                                  StyleID = p.Field<string>("StyleID"),
                                  BrandID = p.Field<string>("BrandID"),
                                  SeasonID = p.Field<string>("SeasonID"),
                                  Article = p.Field<string>("Article"),
                                  PatternCode = p.Field<string>("PatternCode")
                              } into g
                              select new
                              {
                                  ID = g.Key.ID,
                                  StyleID = g.Key.StyleID,
                                  BrandID = g.Key.BrandID,
                                  SeasonID = g.Key.SeasonID,
                                  Article = g.Key.Article,
                                  PatternCode = g.Key.PatternCode,
                                  QTY = g.Sum(p => p.Field<int>("QTY"))
                              }).ToList();
     Data3 =ConvertToDataTable(temp);
     
     public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
