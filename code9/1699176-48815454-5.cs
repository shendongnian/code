    public static List<T> ParseCsvInfo<T>(List<String[]> split) where T : new()
    {
        // No template row, or only a template row but no data. Abort.
        if (split.Count < 2)
            return new List<T>();
        String[] templateRow = split[0];
        // Create a dictionary of rows and their index in the file data.
        Dictionary<String, Int32> columnIndexing = new Dictionary<String, Int32>();
        for (Int32 i = 0; i < templateRow.Length; i++)
        {
            String colHeader = templateRow[i].Trim().ToUpper();
            if (!columnIndexing.ContainsKey(colHeader))
                columnIndexing.Add(colHeader, i);
        }
        // Prepare the array of property info. We set the length so the highest found column index exists in it.
        PropertyInfo[] propIndexing = new PropertyInfo[columnIndexing.Values.Max() + 1];
        // go over the properties of the given type, see which ones have a CsvColumnAttribute, and put these in the list at their CSV index.
        PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (PropertyInfo p in properties)
        {
            object[] attrs = p.GetCustomAttributes(true);
            foreach (Object attr in attrs)
            {
                CsvColumnAttribute csvAttr = attr as CsvColumnAttribute;
                if (csvAttr == null)
                    continue;
                Int32 index;
                if (!columnIndexing.TryGetValue(csvAttr.Name.ToUpper(), out index))
                    continue;
                propIndexing[index] = p;
                break; // Only handle one CsvColumnAttribute per property.
            }
        }
        List<T> objList = new List<T>();
        // start from 1 since the first line is the template with the column names
        for(Int32 i = 1; i < split.Count; i++)
        {
            String[] line = split[i];
            // make new object of the given type
            T obj = new T();
            Int32 col = 0;
            while (line.Length > col && propIndexing.Length > col)
            {
                PropertyInfo prop = propIndexing[col];
                if (prop != null)
                    prop.SetValue(obj, line[col], null);
                col++;
            }
            objList.Add(obj);
        }
        return objList;
    }
