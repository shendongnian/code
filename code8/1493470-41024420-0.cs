    XSSFWorkbook wb = new XSSFWorkbook();
    ISheet sheet = wb.GetSheet("Sheet1") ?? wb.CreateSheet("Sheet1");
    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
        IRow row = sheet.GetRow(i) ?? sh.CreateRow(i);
        for (int j = 0; j < dataGridView1.ColumnCount; j++)
        {
            ICell cell = row.GetCell(j) ?? row.CreateCell(j);
            if (dataGridView1[j, i].Value != null)
            {
                cell.SetCellValue(dataGridView1[j, i].Value.ToString());
            }
        }
    }
    using (var fs = new FileStream("Book1.xlsx", FileMode.Create, FileAccess.Write))
    {
        wb.Write(fs);
    }
