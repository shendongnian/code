    Excel.Worksheet ws1 = excel.ActiveWorkbook.Sheets[1];
    Excel.Worksheet ws2 = excel.ActiveWorkbook.Sheets[2];
    int newRow = 5;
    for (int col = 2; col <= 6; col++)
    {
        string kalipTipi = ws1.Cells[4, 1].Value.ToString();
        string figur = ws1.Cells[5, col].Value.ToString();
        for (int row = 6; row <= 13; row++)
        {
            string ebat = ws1.Cells[row, 1].Value.ToString();
            Excel.Range r = ws2.Rows[string.Format("{0}:{0}", newRow++)];
            r.Cells[1, 1].Value = kalipTipi;
            r.Cells[1, 2].Value = figur;
            r.Cells[1, 3].Value = ebat;
            r.Cells[1, 4].Value = ws1.Cells[row, col].Value;
        }
    }
