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
     Data3 =temp.ToDataTable();
     
    public static DataTable ToDataTable<T>(List<T> items)
     {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Defining type of data column gives proper data table 
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name, type);
        }
        foreach (T item in items)
        {
           var values = new object[Props.Length];
           for (int i = 0; i < Props.Length; i++)
           {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
           }
           dataTable.Rows.Add(values);
      }
      //put a breakpoint here and check datatable
      return dataTable;
    }
