    foreach (DataRow row in data.Rows)
    {
        for (i = 0; i < row.ItemArray.Length; i++)
        {
            if ( row.Table.Columns[i].DataType == typeof(System.DateTime))
                sw.Write( ((DateTime)(row.ItemArray[i])).ToString("dd/MM/yyyy") + "\t | ");
            else
                sw.Write(row.ItemArray[i] + "\t | ");
        }
        sw.WriteLine();
    }
