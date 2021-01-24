    using Microsoft.Office.Interop.Excel;
    Application app = new Application();
    app.Visible = false;
    app.DisplayAlerts = false;
    string[] files = Directory.GetFiles(@"c:\temp\excel");
    foreach (string file in files)
    {
        app.Workbooks.Add(file);
    }
    for (int i = 2; i <= app.Workbooks.Count; i++)
    {
        for (int j = 1; j <= app.Workbooks[i].Worksheets.Count; j++)
        {
            Worksheet ws = app.Workbooks[i].Worksheets[j];
            ws.Copy(app.Workbooks[1].Worksheets[1]);
        }
    }
    app.Workbooks[1].SaveCopyAs(@"c:\temp\excel\output\testFile.xlsx");
    app.Quit();
