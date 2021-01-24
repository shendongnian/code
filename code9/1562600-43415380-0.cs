    FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    
    DataTable dt = new DataTable();
    dt = excelReader.AsDataSet().Tables[0];
    
    Int16 shift = 0;
    if (dt.Rows[0].ItemArray[0].ToString() == "Some Text in the header")
    {
        shift = 1; //If the first row is a header, we need to shift everything up one row.
    }
    
    foreach (DataColumn Col in dt.Columns)
    {
        Col.ColumnName = dt.Rows[shift].ItemArray[Col.Ordinal].ToString();
    }
