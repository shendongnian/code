    private bool ParseWorksheet(HSSFWorkbook wb, int SheetIndex)
    {
        bool result = true;
        HSSFSheet sheet = (HSSFSheet)wb.GetSheetAt(SheetIndex);
        if (sheet.FirstRowNum == sheet.LastRowNum && sheet.LastRowNum == 0) return result;
        StreamWriter sw = new StreamWriter(OutputFileName, true);
        int MaxCol = 0;
        for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
        {
            HSSFRow row = (HSSFRow)sheet.GetRow(i);
            MaxCol = Math.Max(MaxCol, row.LastCellNum);
        }
        for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
        {
            string OutputRow = String.Empty;
            HSSFRow row = (HSSFRow)sheet.GetRow(i);
            for (int j = 0; j < MaxCol; j++)
            {
                HSSFCell cell = (HSSFCell)row.GetCell(j);
                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case NPOI.SS.UserModel.CellType.Boolean:
                            OutputRow += FormatValue(cell.BooleanCellValue.ToString(), AddQuotes, c) + Delimiter;
                            break;
                        case NPOI.SS.UserModel.CellType.Formula:
                            OutputRow += FormatValue(cell.CachedFormulaResultType.ToString(), AddQuotes, c) + Delimiter;
                            break;
                        case NPOI.SS.UserModel.CellType.Numeric:
                            OutputRow += FormatValue((NPOI.SS.UserModel.DateUtil.IsCellDateFormatted(cell) ? cell.DateCellValue.ToShortDateString() : cell.NumericCellValue.ToString()), AddQuotes, c) + Delimiter;
                            break;
                        case NPOI.SS.UserModel.CellType.Blank:
                            OutputRow += Delimiter;
                            break;
                        case NPOI.SS.UserModel.CellType.String:
                            OutputRow += FormatValue(cell.StringCellValue.ToString().Replace('\n', ' ').TrimEnd(), AddQuotes, c) + Delimiter; //replace the new line character to space due to formatting issue.
                            break;
                        default:
                            result = false;
                            break;
                    }
                }
                else
                {
                    OutputRow += Delimiter;
                }
            }
            OutputRow = OutputRow.Remove(OutputRow.Length - 1);
            sw.WriteLine(OutputRow);
        }
        sw.Flush();
        sw.Close();
        return result;
    }
