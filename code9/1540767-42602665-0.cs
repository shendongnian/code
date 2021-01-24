    public class ExcelFile
    {
        public string Path = @"C:\test.xlsx";
        private Excel.Application xl = new Excel.Application();
        private Excel.Workbook WB;
        public string FullText;
        private Excel.Range rng;
        private Dictionary<string, string> Variables;
        public ExcelFile()
        {
            StringBuilder sb = new StringBuilder();
            WB = xl.Workbooks.Open(Path);
            xl.Visible = true;
            foreach (Excel.Worksheet CurrentWS in WB.Worksheets)
            {
                rng = CurrentWS.UsedRange;
                for (int i = 1; i < rng.Count; i++)
                { 
                    sb.append(rng.Cells[i].Value); 
                }
            }
            FullText = sb.ToString();
            WB.Close(false);
            xl.Quit();
        }
    }
