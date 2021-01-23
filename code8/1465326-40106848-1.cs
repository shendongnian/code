    worksheetPart.Worksheet = new Worksheet(new SheetViews(new SheetView { WorkbookViewId = 0, ShowGridLines = new BooleanValue(false) }));
    //....code omitted for brevity
    Columns columns = new Columns();
    columns.Append(new Column() { Min = 1, Max = 3, Width = 20, CustomWidth = true });
    columns.Append(new Column() { Min = 4, Max = 4, Width = 30, CustomWidth = true });
    worksheetPart.Worksheet.Append(columns);
    worksheetPart.Worksheet.Append(new SheetData());
