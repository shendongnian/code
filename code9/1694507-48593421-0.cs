    using Spire.Xls;
    
    namespace Detect_Merged_Cells
    {
        class Program
        {
            static void Main(string[] args)
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile("Sample.xlsx");
                Worksheet sheet = workbook.Worksheets[0];
    
                CellRange[] range = sheet.MergedCells;
                foreach (CellRange cell in range)
                {
                    cell.UnMerge();
                }
                workbook.SaveToFile("Output.xlsx",ExcelVersion.Version2010);
            }
        }
    }
