    worksheet.TrimLastEmptyRows();
    public static void TrimLastEmptyRows(this ExcelWorksheet worksheet)
        {
            while (worksheet.IsLastRowEmpty())
                worksheet.DeleteRow(worksheet.Dimension.End.Row);
        }
    public static bool IsLastRowEmpty(this ExcelWorksheet worksheet)
        {
            var empties = new List<bool>();
            for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
            {
                var rowEmpty = worksheet.Cells[worksheet.Dimension.End.Row, i].Value == null ? true : false;
                empties.Add(rowEmpty);
            }
            return empties.All(e => e);
        }
