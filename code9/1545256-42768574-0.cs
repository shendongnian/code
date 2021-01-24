    XLWorkbook workbook = new XLWorkbook();
    DataTable dt = new DataTable() { TableName = "New Worksheet" };
    DataSet ds = new DataSet();
    //input data
    var columns = new[] { "column1", "column2", "column3" };
    var rows = new object[][] 
    {
         new object[] {"1", 2, false },
         new object[] { "test", 10000, 19.9 }
    };
    //Add columns
    dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
    //Add rows
    foreach (var row in rows)
    {
        dt.Rows.Add(row);
    }
    //Convert datatable to dataset and add it to the workbook as worksheet
    ds.Tables.Add(dt);
    workbook.Worksheets.Add(ds);
    
    //save
    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string savePath = Path.Combine(desktopPath, "test.xlsx");
    workbook.SaveAs(savePath, false);
