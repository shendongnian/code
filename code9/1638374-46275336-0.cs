    Excel.Application app = new Excel.Application();
    .
    .
    foreach (string file in fopen.FileNames)
    {
        //file stuff
    //} foreach loop should be closed here.
                app.DisplayAlerts = false;
                wb.SaveAs(save1 + ".csv", Excel.XlFileFormat.xlCSVWindows);
                wb.Close();       //save as
                app.Workbooks.Close();
                app.Quit();
    //} missing but implied
