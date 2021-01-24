    using (var memoryStream = new MemoryStream())
    {
        using (XLWorkbook workbook = new XLWorkbook())
        {
            using (IXLWorksheet worksheet = workbook.AddWorksheet("WorksheetName"))
            {
                var toExport = GetData();
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Value = "Column 1";
                worksheet.Cell(1, 2).Value = "Column 2";
                worksheet.Cell(1, 3).Value = "Column 3";
            
                // Export the data and set some properties           
                worksheet.Cell(2, 1).Value = toExport.AsEnumerable();
                worksheet.RangeUsed().SetAutoFilter();
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(memoryStream);
                memoryStream.Position = 0;
                return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "filename.xlsx");
            }
        }
    }
