    using (var excel = new ExcelPackage())
    {
        var workBookName = DateTime.Now.ToString("ddMMMyyyy-HHmmss");
        var worksheet = excel.Workbook.Worksheets.Add(workBookName);
                
        worksheet.Cells[1, 1].Value = "Logistics";
        worksheet.Cells[2, 1].Value = "Tracking Number";
        worksheet.Cells[4, 2].Value = "Date - ";
        worksheet.Cells[4, 3].Value = dateTimePicker1.Value.ToString("dd/MMM/yyyy");
        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
        {
            worksheet.Cells[6, i].Value = dataGridView1.Columns[i - 1].HeaderText;
        }
        worksheet.Cells["6:6"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        worksheet.Cells["6:6"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
        //
        //..etc
        //
        excel.SaveAs(new FileInfo("Tracking Number Report " + workBookName + ".xlsx"));
    }
