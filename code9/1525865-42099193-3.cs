    // Get your data directly from EF,
    // or from whatever other source into a list,
    // or Enumerable of the type
    List<MyEntity> data = _whateverService.GetData();
    using (ExcelPackage pck = new ExcelPackage())
    {
       // Create a new sheet
       var newSheet = pck.Workbook.Worksheets.Add("Sheet 1");
       // Set the header:
       newSheet.Cells["A1"].Value = "Column 1 - Erm ID?";
       newSheet.Cells["B1"].Value = "Column 2 - Some data";
       newSheet.Cells["C1"].Value = "Column 3 - Other data";
      row = 2;
      foreach (var datarow in data)
      {
          // Set the data:
          newSheet.Cells["A" + row].Value = datarow.Id;
          newSheet.Cells["B" + row].Value = datarow.Column2;
          newSheet.Cells["C" + row].Value = datarow.Cilumn3;
          row++;
      }
    }
