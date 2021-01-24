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
                for (int i = 1; i <= rng.Rows.Count; i++)
                {
                    for (int j = 1; j <=  rng.Columns.Count; j++)
                    {
                        sb.append(rng.Cells[i, j].Value); 
                    }
                }
            }
            FullText = sb.ToString();
            WB.Close(false);
            xl.Quit();
        }
    }
