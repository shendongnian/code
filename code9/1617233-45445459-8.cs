    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    void test()
    {
        Excel.Application xlApp = csXL.StartExcel();
        Excel.Worksheet ws = xlApp.ActiveSheet;
        int irow = getLastRow(ws);
    }
    public static Excel.Application StartExcel()
    {
        Excel.Application instance = null;
        try { instance = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); }
        catch (System.Runtime.InteropServices.COMException ex) { instance = new Excel.Application(); }
        return instance;
    }
