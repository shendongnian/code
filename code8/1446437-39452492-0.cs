    var stringColumns = table.Columns.Cast<DataColumn>().Where(c => c.DataType == typeof(string)).ToList();
    foreach (DataRow row in table.Rows)
    {
        for (int i = 0; i < stringColumns.Count; i++)
        {
            string field = row.Field<string>(i);
            if (string.IsNullOrEmpty(field))
            {
                // check all after this:
                for (int ii = i + 1; ii < stringColumns.Count; ii++)
                {
                    string nextField = row.Field<string>(ii);
                    if (!string.IsNullOrEmpty(nextField))
                    {
                        row.SetField(i, nextField);
                        break;
                    }
                }
            }
        }
    }
