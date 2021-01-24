    public static void ExportToPipe(RibbonControlEventArgs e)
    {
        string ExportName = @"D:\Pipe.txt";
        Excel.Window window = e.Control.Context;
        Excel.Worksheet sheet = ((Excel.Worksheet)window.Application.ActiveSheet);
        Excel.Range last = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing); 
        int lastUsedRow = last.Row;
        int lastUsedColumn = last.Column;
        string output = "";
        for (int i = 1; i <= lastUsedRow; i++)
        {
            for (int j = 1; j <= lastUsedColumn; j++)
            {
                if (sheet.Cells[i, j].Value != null)
                {
                    output += sheet.Cells[i, j].Value.ToString();                        
                }
                output += "|";
            }
            output += Environment.NewLine;
         }
         FileStream fs = new FileStream(ExportName, FileMode.Create, FileAccess.Write);
         StreamWriter writer = new StreamWriter(fs);
         writer.Write(output);
         writer.Close();
    }
