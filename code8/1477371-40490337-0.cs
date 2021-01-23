    foreach (DataTable table in _dataset)
    {
        foreach (DataRow dataRow in table.Rows)
        {
             foreach(DataColumn dataColumn in dtTable.Columns)
             {
                  Console.Writeline([dataColumn].ToString());
             }
        }
    }
