    //create some dummy table for this test
    DataTable table = new DataTable();
    //make a few columns
    table.Columns.AddRange(
        new DataColumn[] { new DataColumn("Column 1",typeof(int)),
        new DataColumn("Column 2", typeof(int)),
        new DataColumn("Column 3", typeof(int)) }
    );
    //populate with some randomness
    Random r = new Random();
    for (int i = 0; i < 100; i++)
    {
        var newRow = table.NewRow();
        newRow[0] = r.Next(0, 10);
        newRow[1] = r.Next(0, 10);
        newRow[2] = r.Next(0, 10);
        table.Rows.Add(newRow);
    }
    //create workbook
    XLWorkbook wb = new XLWorkbook();
    var sheet = wb.AddWorksheet("My datatable");
    //just showing how to add a bit of extra data to the sheet, not required
    sheet.Cell(1, 1).SetValue<string>("Title: this is just a test");
    sheet.Cell(1, 3).SetValue<string>("Date: " + DateTime.Now);
    //dump table in sheet
    sheet.Cell(2, 1).InsertTable(table);
    sheet.Columns().AdjustToContents();
    wb.SaveAs(@"c:\test\dtable.xlsx",false);
