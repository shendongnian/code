            using (var xlsx = File.Create("Text.xlsx"))
            using (var pkg = new ExcelPackage())
            {
                var ws = pkg.Workbook.Worksheets.Add("Sheet1");
                var r = 0;
                ws.Cells[++r, 1].Value = "Values";
                ws.Cells[++r, 1].Value = 1171.2;
                ws.Cells[++r, 1].Value = 1.1;
                ws.Cells[++r, 1].Value = 1.2;
                ws.Cells[++r, 1].Value = 1.3;
                ws.Column(1).Style.Numberformat.Format = "General"; // Default
                //ws.Column(1).Style.Numberformat.Format = "0.00";    // Numeric with fixed decimals
                //ws.Column(1).Style.Numberformat.Format = "@";       // Text
                pkg.SaveAs(xlsx);
            }
