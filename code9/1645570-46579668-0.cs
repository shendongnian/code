        private static void CopyImage(ExcelPackage sourceExcelPackage, ExcelWorksheet destWorksheet)
        {
            var image = GetImage("Pic01", sourceExcelPackage);
            ExcelPicture pic = destWorksheet.Drawings.AddPicture("Pic01", image.Image);
            pic.From.Column = image.From.Column;
            pic.From.Row = image.From.Row;
            pic.To.Column = image.To.Column;
            pic.To.Row = image.To.Row;
            var destRow = 1;
            var destCol = 1;
            pic.SetPosition(destRow, Pixel2MTU(image.From.RowOff), destCol, Pixel2MTU(image.From.ColumnOff));
            pic.EditAs = eEditAs.TwoCell;
            pic.AdjustPositionAndSize();
        }
        private static ExcelPicture GetImage(string pictureName, ExcelPackage excelFile)
        {
            var sheet = excelFile.Workbook.Worksheets.First();
            var pic = sheet.Drawings[pictureName] as ExcelPicture;
            return pic;
        }
        private static int Pixel2MTU(int fromRowOff)
        {
            return fromRowOff / ExcelDrawing.EMU_PER_PIXEL;
        }
