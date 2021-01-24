    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application excel = null;
    try
    {
      excel = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    }
    catch (COMException exc)
    {
    // ....
    }
