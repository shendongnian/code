     public static DataTable ToDataTableVendorExp<T>(List<T> items,List<string> ExcludeColumnName)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(a => a.PropertyType != typeof(System.Object)).Cast<PropertyInfo>().ToArray();
            List<int> lstIgnoreIndex = new List<int>();
            int colIndex = 0;
            foreach (PropertyInfo prop in Props)
            {
                
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                string dtcolumname = prop.Name;
                //check if property name of list dont need to export then ignore.
                if (ExcludeColumnName != null && ExcludeColumnName.IndexOf(dtcolumname) >= 0)
                {
                    lstIgnoreIndex.Add(colIndex);
                }
                else
                {
                    if (Attribute.IsDefined(prop, typeof(DisplayNameRptAttribute)))
                    {
                        var attrvalue = (DisplayNameRptAttribute)prop.GetCustomAttribute(typeof(DisplayNameRptAttribute));
                        dtcolumname = attrvalue.GetName();
                    }
                    dataTable.Columns.Add(dtcolumname, type);
                }
                colIndex++;
            }
            foreach (T item in items)
            {
                //if ignore 3 properties out of 10 then only 7 required.
                int totlaproplength = Props.Length;
                if (lstIgnoreIndex.Count > 0)
                    totlaproplength = totlaproplength - lstIgnoreIndex.Count;
                var values = new object[totlaproplength];
                for (int i = 0; i < Props.Length; i++)
                {
                    if (lstIgnoreIndex.IndexOf(i) >= 0)
                        continue;
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                    if (Props[i].ToString() == "System.DateTime Date")
                    {
                        values[i] = String.Format("{0:MM/dd/yyyy}", (Props[i].GetValue(item, null)));
                    }
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
