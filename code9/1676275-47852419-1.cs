    public static bool RunMacro(string Path, string MacroName, bool Close, params object[] Arguments)
    {
        Microsoft.Office.Interop.Excel.Application aApplication = null;
        bool aCloseApplication = true;
        bool aResult = false;
        try
        {
            aApplication = (Microsoft.Office.Interop.Excel.Application)Marshal.GetActiveObject("Excel.Application");
            aCloseApplication = false;
        }
        catch (COMException aCOMException)
        {
            aApplication = new Microsoft.Office.Interop.Excel.Application();
            aApplication.Visible = false;
        }
        if (aApplication != null)
        {
            aApplication.ScreenUpdating = false;
            Microsoft.Office.Interop.Excel.Workbook aWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet aWorksheet = null;
            bool aCloseWorkbook = true;
            try
            {
                if (IsEdited(aApplication))
                {
                    throw new Exception("Excel is in cell edit mode. Please stop editing cell and run import again");
                }
                else
                {
                    var workbooks = aApplication.Workbooks;
                    for (int i = 0; i < workbooks.Count; i++)
                    {
                        var workbook = aApplication.Workbooks.Item[i + 1];
                        if (workbook.FullName == Path)
                        {
                            aWorkbook = workbook;
                            aCloseWorkbook = false;
                            break;
                        }
                        else
                        {
                            Marshal.ReleaseComObject(workbook);
                        }
                    }
                    if (aWorkbook == null)
                        aWorkbook = workbooks.Open(Path);
                    Marshal.ReleaseComObject(workbooks);
                    // Run macro here
                    aApplication.Run(string.Format("{0}!{1}", System.IO.Path.GetFileName(Path), MacroName),
                        Arguments);
                    aResult = true;
                }
            }
            finally
            {
                if (aWorksheet != null)
                {
                    Marshal.ReleaseComObject(aWorksheet);
                }
                //does not work here!!! I want to close excel here 
                if (aWorkbook != null)
                    aWorkbook.Close();
                aApplication.Quit();
                Marshal.ReleaseComObject(aWorkbook);
                Marshal.ReleaseComObject(aApplication);
            }
        }
        return aResult;
    }
