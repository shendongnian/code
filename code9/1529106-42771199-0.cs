    Microsoft.Office.Interop.Excel.Application xlApp = null;
    //Microsoft.Office.Interop.Excel.Workbooks wbs = null;
    Microsoft.Office.Interop.Excel.Workbook wb = null;
    Microsoft.Office.Interop.Excel.Worksheet ws = null;
    bool wasFoundRunning = false;
    Microsoft.Office.Interop.Excel.Application tApp = null;
     //Checks to see if excel is opened
    Console.WriteLine("CDC is looking for Excel...");
       try
       {
        tApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        wasFoundRunning = true;
       }
        catch (Exception)//Excel not open
       {
        wasFoundRunning = false;
       }
       if (true == wasFoundRunning)
       {
        //Control Excel
       }
