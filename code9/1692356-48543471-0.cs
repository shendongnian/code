      private static Aspose.Cells.Workbook AddExcelWaterMark(Aspose.Cells.Workbook workbook)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/images/ExcelBackGround.png");
                byte[] bgBuffer = File.ReadAllBytes(path);
                foreach (Aspose.Cells.Worksheet sheet in workbook.Worksheets)
                    sheet.SetBackground(bgBuffer);
                return workbook;
            }
            catch
            {
                return workbook;
            }
        }
