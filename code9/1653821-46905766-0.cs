    using (var sw = new StreamWriter("/path/to/source/file.csv", false))
    {
        // assume Exceldt is your 'DataTable' object
        int colCount = Exceldt.Columns.Count;
        foreach (DataRow row in Exceldt.Rows)
        {
            for (int i = 0; i < colCount; i++)
            {
                if (!Convert.IsDBNull(row[i]))
                {
                    sw.Write(row[i].ToString());
                }
                if (i < colCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
    }
