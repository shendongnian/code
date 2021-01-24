    public class ExcelTools
    {
        public static byte[] WriteExcel(DataTable dtExport, string[] header = null, string[] excludeColumns = null, bool rtl = true)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                XSSFWorkbook xssfWorkbook = new XSSFWorkbook();
                ISheet sheet = null;
                //-----------Create Style And Font
                var hFont = xssfWorkbook.CreateFont();
                hFont.FontHeightInPoints = 11;
                hFont.FontName = "Tahoma";
                var defaultStyle = xssfWorkbook.CreateCellStyle();
                defaultStyle.SetFont(hFont);
                var defaultHeaderStyle = xssfWorkbook.CreateCellStyle();
                defaultHeaderStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.BlueGrey.Index;
                defaultHeaderStyle.SetFont(hFont);
                if (xssfWorkbook.NumberOfSheets == 0)
                {
                    sheet = xssfWorkbook.CreateSheet(String.IsNullOrWhiteSpace(dtExport.TableName) ? "ExportReport" : dtExport.TableName);
                    sheet.IsRightToLeft = true;
                    sheet.CreateRow(0);
                }
                if (header != null)
                {
                    for (int index = 0; index < header.Length; index++)
                    {
                        var strHeader = header[index];
                        sheet.GetRow(0).CreateCell(index).SetCellValue(header[index]);
                        sheet.GetRow(0).GetCell(index).CellStyle = defaultHeaderStyle;
                    }
                }
                else
                {
                    int index = 0;
                    foreach (DataColumn col in dtExport.Columns)
                    {
                        if (excludeColumns != null && excludeColumns.Contains(col.ColumnName))
                            continue;
                        sheet.GetRow(0).CreateCell(index).SetCellValue(col.ColumnName);
                        index++;
                    }
                }
                sheet = xssfWorkbook.GetSheetAt(0);
                int indexRow = sheet.LastRowNum + 1;
                for (; indexRow < dtExport.Rows.Count + 1; indexRow++)
                {
                    sheet.CreateRow(indexRow);
                    int index = 0;
                    foreach (DataColumn col in dtExport.Columns)
                    {
                        if (excludeColumns != null && excludeColumns.Contains(col.ColumnName))
                            continue;
                        sheet.GetRow(indexRow).CreateCell(index).SetCellValue(dtExport.Rows[indexRow - 1][col.ColumnName].ToStringTD());
                        sheet.GetRow(indexRow).GetCell(index).CellStyle = defaultStyle;
                        index++;
                    }
                }
                for (int index = 0; index < sheet.GetRow(0).Cells.Count; index++)
                {
                    sheet.AutoSizeColumn(index);
                }
                xssfWorkbook.Write(ms);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
