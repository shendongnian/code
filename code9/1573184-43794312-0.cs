    using (var package = new ExcelPackage(new FileInfo(path)))
    {
        var sheet = package.Workbook.Worksheets[1];
        for (int i = 1; i <= 4; ++i)
        {
            var cell = sheet.Cells[1, i];
            if (cell.IsRichText) {
                foreach (var element in cell.RichText)
                {
                    if (element.Bold) 
                        Console.WriteLine("Rich Text cell {0}: bold text: [{1}]", i, element.Text.Trim());
                }
            }
            else {
                if (cell.Style.Font.Bold)
                    Console.WriteLine("Single-line cell {0}: bold text: [{1}]", i, cell.Value);
            }
        }
    }
