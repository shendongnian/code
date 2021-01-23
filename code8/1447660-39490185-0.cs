    for(int i = 0; i < dataTable.Rows.Count; i++)
    {
        DataRow row = dataTable.Rows[i];
        foreach (DataColumn col in dataTable.Columns)
        {
            Console.WriteLine("Row#:{0} Column:{1} Type:{2} Value:{3}",
                i + 1,
                col.ColumnName, 
                col.DataType,
                row[col]);
        }
    }
