    ExcelCommand = new OleDbCommand(ExcelQuery, ExcelConnection);
    OleDbDataReader reader = ExcelCommand.ExecuteReader();
    DateTime orderDate;
    while (reader.Read())
    {
        string colA = reader.GetValue(0).ToString();
        if (DateTime.TryParse(colA, out orderDate))
        {
            // do something with orderDate here
        }
    }
    reader.Close();
