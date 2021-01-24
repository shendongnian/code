    using (ExcelPackage phone_package = new ExcelPackage(new FileInfo(filepath)))
    {
        var phone_workbook = phone_package.Workbook;
        if (phone_workbook != null && phone_workbook.Worksheets.Any())
        {
            ExcelWorksheet ws = phone_workbook.Worksheets.Add("Country");
            var dt = new DataTable();
            dt.Columns.Add("Germany", typeof(string));
            dt.Columns.Add("Italy", typeof(string));
            ws.Cells["G2"].LoadFromDataTable(dt, true);
            phone_package.SaveAs(filename);
        }
    }
