    HSSFWorkbook spreadsheet = new HSSFWorkbook();
    DataSet results = GetSalesDataFromDatabase();
    //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
    HSSFSheet sheet1 = spreadsheet.CreateSheet("Sheet1");
    int rowIndex = 0;
    foreach (DataRow row in results.Tables[0].Rows)
    {                
      HSSFRow dataRow = sheet1.CreateRow(rowIndex);
      foreach (DataColumn column in results.Tables[0].Columns)
      {
        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());          
      }
      rowIndex++;
    }
    
    for(var i = 0; i< results.Tables[0].Columns.Count; i++)
    {
      sheet1.AutoSizeColumn(i);
    }
    //Write the stream data of workbook to the file 'test.xls' in the temporary directory
    FileStream file = new FileStream(Path.Combine(Path.GetTempPath(), "test.xls"), FileMode.Create);
    spreadsheet.Write(file);
    file.Close();
