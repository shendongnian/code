    using Microsoft.Office.Interop.Excel;
    using System.Collections.Generic;
    
    class Startup
    {
        static void Main()
        {
            Application oXL = new Application();
            Workbook wb = oXL.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)oXL.ActiveSheet;
    
            Dictionary<int, string> DictionnaireFinal = new Dictionary<int, string>();
            DictionnaireFinal.Add(1, "vit");
            DictionnaireFinal.Add(2, "vito");
            DictionnaireFinal.Add(3, "vitya");
    
            oXL.Visible = true;
    
            ws.Cells[1, 1] = "Mot";
            ws.Cells[1, 2] = "Definition";
    
            int i = 1;
    
            foreach (var b in DictionnaireFinal)
            {
                i++;
                ws.Cells[i, 1] = b.Key;
                ws.Cells[i, 2] = b.Value;
            }
        }
    }
