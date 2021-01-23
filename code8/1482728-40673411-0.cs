    var book = new Workbook(dir + "sample.xlsx");
    var sheet = book.Worksheets[0];
    var pivot = sheet.PivotTables[0];
    
    // DataBodyRange returns CellArea that represents range between the header row & insert row
    var dataBodyRange = pivot.DataBodyRange;
    Console.WriteLine(dataBodyRange);
    // TableRange1 returns complete Pivot Table area except page fields
    var tableRange1 = pivot.TableRange1;
    Console.WriteLine(tableRange1);
    // TableRange2 returns complete Pivot Table area including page fields
    var tableRange2 = pivot.TableRange2;
    Console.WriteLine(tableRange2);
    // ColumnRange returns range that represents the column area of the Pivot Table
    var columnRange = pivot.ColumnRange;
    Console.WriteLine(columnRange);
    // RowRange returns range that represents the row area of the Pivot Table
    var rowRange = pivot.RowRange;
    Console.WriteLine(rowRange);
