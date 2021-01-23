    string line;
    System.Data.DataTable csvData = new System.Data.DataTable();
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
        DataRow newRow = csvData.NewRow();
        newRow["OnlyColumn"] = line;
        csvData.Rows.Add(newRow);
    }
    file.Close();
    InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tablenaam);
