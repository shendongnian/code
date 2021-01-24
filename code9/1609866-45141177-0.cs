    static void Main(string[] args)
    {
        using (OfficeOpenXml.ExcelPackage ep = new OfficeOpenXml.ExcelPackage())
        {
            var ws = ep.Workbook.Worksheets.Add("sheet 1");
            ws.Cells[1, 1].IsRichText = true;
            ws.Cells[1, 1].RichText.Add("first ");
            ws.Cells[1, 1].RichText.Add(" second");
            ws.Cells[1, 1].RichText.Text = ws.Cells[1, 1].RichText.Text.Insert(6, "Inserted");
            Console.WriteLine(ws.Cells[1, 1].Text); // shows your bug
        }
    }
