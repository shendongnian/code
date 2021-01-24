        var workbook = 
          excelApp.Workbooks.Open(_mirrorFileName,Type.Missing,Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
          var worksheet = (Worksheet)workbook.Worksheets[1];
            var rowCount = worksheet.UsedRange.Rows.Count;
