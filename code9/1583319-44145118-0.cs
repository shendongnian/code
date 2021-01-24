    // DataTable with original data
    // May contain DataTime with zero time.
    var dt = new DataTable();
    // DataTable with Date converted to string.
    var dt2 = new DataTable();
    var dateIndexes = new HashSet<int>();
    // Create columns in dt2, changing DateTime with zero time to string type
    foreach (DataColumn column in dt.Columns)
    {
        if (column.DataType == typeof(DateTime) &&
            dt.Rows.Cast<DataRow>()
                .Select(row => (DateTime)row[column])
                .All(dateTime => dateTime.TimeOfDay.Ticks == 0))
        {
            // If all time is zero then create string type column.
            dt2.Columns.Add(column.ColumnName, typeof(string));
            // Remember the index of the column with zero time
            dateIndexes.Add(column.Ordinal);
        }
        else
        {
            // Create column same type.
            dt2.Columns.Add(column.ColumnName, column.DataType);
        }
    }
    // Copy rows
    foreach (DataRow row in dt.Rows)
    {
        var newRow = dt2.NewRow();
        dt2.Rows.Add(newRow);
        for (int i = 0; i < row.ItemArray.Length; i++)
        {
            if (dateIndexes.Contains(i))
            {
                // Column with zero time. Convert it to string.
                newRow[i] = ((DateTime)row[i]).ToShortDateString();
            }
            else
            {
                // Copy as is.
                newRow[i] = row[i];
            }
        }                    
    }
