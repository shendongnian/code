    var workbook = new XSSFWorkbook(dataStream);
    var sheet = workbook.GetSheetAt(0);
    var rowEnumerator = sheet.GetRowEnumerator();
    while (rowEnumerator.MoveNext())
    {
            IRow row = (XSSFRow)_rowEnumerator.Current;
            int colCount = row.LastCellNum;
            var tableRow = new TableRow(colCount);
            for (var c = 0; c < colCount; c++)
            {
                var cell = row.GetCell(c);
                if (cell != null)
                {
                     if (IsCreditCardNumber(c))
                     {
                         ...
                     }
                }
            }
    }
