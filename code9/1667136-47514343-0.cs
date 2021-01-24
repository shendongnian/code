        /// <Summary>
        /// Convert a IEnumerable to a DataTable.
        /// <TypeParam name="T">Type representing the type to convert.</TypeParam>
        /// <param name="source">List of requested type representing the values to convert.</param>
        /// <returns> returns a DataTable</returns>
        /// </Summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            // Use reflection to get the properties for the type we’re converting to a DataTable.
            var props = typeof(T).GetProperties();
            // Build the structure of the DataTable by converting the PropertyInfo[] into DataColumn[] using property list
            // Add each DataColumn to the DataTable at one time with the AddRange method.
            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, BaseType(p.PropertyType))).ToArray());
            // Populate the property values to the DataTable
            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );
            return dt;
        }
    //To call the above method:
    var dt = JoinResult.ToDataTable();
