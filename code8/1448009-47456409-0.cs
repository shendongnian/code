    var workbook = new XLWorkbook();
    
    DataTable userData = new DataTable("Sheet1");
    userData.Columns.Add("Master Column");
    workbook.AddWorksheet(userData);
    var worksheet = workbook.Worksheet(1);
    
    DataTable validationTable = new DataTable();
    validationTable.Columns.Add("DropDownItems");
    validationTable.TableName = "Sheet2";
    
    DataRow dr = validationTable.NewRow();
    dr["DropDownItems"] = "Item1";
    validationTable.Rows.Add(dr);
    
    dr = validationTable.NewRow();
    dr["DropDownItems"] = "Item2";
    validationTable.Rows.Add(dr);
    
    dr = validationTable.NewRow();
    dr["DropDownItems"] = "Item3";
    validationTable.Rows.Add(dr);
    
    var worksheet2 = workbook.AddWorksheet(validationTable);
    worksheet.Column(1).SetDataValidation().List(worksheet2.Range("A2:A4"), true);
    
    //optional: you can hide the data validation sheet from your users if you want
    //worksheet2.Hide();
    
    workbook.SaveAs(@"C:\myworkbook.xlsx");
