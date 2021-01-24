    [ExcelCommand(MenuText = "My Test Command", ShortCut = "^Q")]
    public static void Teste()
    {
        dynamic xlApp = ExcelDnaUtil.Application;
        var ws = xlApp.Sheets[1];
        var range = ws.Cells[1, 1];
        range.Value2 = "foo bar";
    }
