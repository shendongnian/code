        Microsoft.Office.Interop.Excel.Application oExcelApp = null;
        try
        {
           oExcelapp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        }
        catch {} // can do intelligent stuff here    
        if (oExcelApp == null)
        { Console.WriteLine("Excel not found"); }
        else
        {Console.WriteLine(oExcelApp.ActiveWorkbook.FullName);}
