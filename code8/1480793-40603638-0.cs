    int[] inputElements = Enumerable.Range(1, 12).ToArray(); // Will give you array(1-12)
    DataTable outputTable = new DataTable();
    outputTable.Columns.Add("A");
    outputTable.Columns.Add("B");
    outputTable.Columns.Add("C");
    outputTable.Columns.Add("D");
    for (int i = 0; i < inputElements.Length - 1; )
    {
        DataRow dRow = outputTable.NewRow();
        for (int j = 0; j < 4; j++)
        {
            dRow[j] = inputElements[i];
            i++;
        }
        outputTable.Rows.Add(dRow);
    }
