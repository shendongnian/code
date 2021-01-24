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
        // Prepare the arrays of property parse info. We set the length
        // so the highest found column index exists in it.
        Int32 numCols = columnIndexing.Values.Max() + 1;
        // Actual property to fill in
        PropertyInfo[] properties = new PropertyInfo[numCols];
        // Regex to validate the string before parsing
        Regex[] propValidators = new Regex[numCols];
        // The type of the property for automatic parsing
        TypeConverter[] propconverters = new TypeConverter[numCols];
        // go over the properties of the given type, see which ones have a
        // CsvColumnAttribute, and put these in the list at their CSV index.
        foreach (PropertyInfo p in typeof(T).GetProperties())
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
                properties[index] = p;
                propValidators[index] = csvAttr.ValidationRegex;
                // automatic type converter.
                propconverters[index] = TypeDescriptor.GetConverter(p.PropertyType);
                break; // Only handle one CsvColumnAttribute per property.
            }
        }
        List<T> objList = new List<T>();
        // start from 1 since the first line is the template with the column names
        for (Int32 i = 1; i < split.Count; i++)
        {
            Boolean abortLine = false;
            String[] line = split[i];
            // make new object of the given type
            T obj = new T();
            Int32 col = 0;
            while (line.Length > col && properties.Length > col)
            {
                String curVal = line[col];
                PropertyInfo prop = properties[col];
                if (prop != null)
                {
                    // check validity. Abort if not valid.
                    Boolean valid = propValidators[col].IsMatch(curVal);
                    if (!valid)
                    {
                        // Add logging here? We have the line and column index.
                        abortLine = true;
                        break;
                    }
                    // Parsing should ALWAYS fail gracefully to an assignable type. Checking is the regex's job.
                    Object value = propconverters[col].ConvertFromString(curVal);
                    prop.SetValue(obj, value, null);
                }
                col++;
            }
            if (!abortLine)
                objList.Add(obj);
        }
        return objList;
    }
